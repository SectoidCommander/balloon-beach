using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class App_Initialize : MonoBehaviour
{
    public GameObject inMenuUI;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject adButton;
    public GameObject restartButton;

    public GameObject player;
    public GameObject mainCamera;
    private bool hasGameStarted = false;
    private bool gameIsPaused = false;
    private bool hasSeenRewardedAd = false;

    void Awake()
	{
		Shader.SetGlobalFloat("_Curvature", 2.0f);
		Shader.SetGlobalFloat("_Trimming", 0.1f);
        Application.targetFrameRate = 60;
	}

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Player>().SetFrozen(true);
        mainCamera.GetComponent<CameraFollow>().FreezeCamera(true);
        inMenuUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
    }

    public void PlayButton()
    {
        if (hasGameStarted)
        {
            StartCoroutine(StartGame(1.0f));
        }
        else
        {
            StartCoroutine(StartGame(0.0f));
        }
        
    }

    public void PauseGame()
    {
        gameIsPaused = true;
        player.GetComponent<Player>().SetFrozen(true);

        mainCamera.GetComponent<CameraFollow>().FreezeCamera(true);

        hasGameStarted = true;
        inMenuUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
    }

    IEnumerator StartGame(float waitTime)
    {
        gameIsPaused = false;
        inMenuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(true);
        gameOverUI.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(waitTime);
        if (!gameIsPaused)
        {
            mainCamera.GetComponent<CameraFollow>().FreezeCamera(false);
            player.GetComponent<Player>().SetFrozen(false);
        }
    }

    public void GameOver()
    {
        player.GetComponent<Player>().SetFrozen(true);
        mainCamera.GetComponent<CameraFollow>().FreezeCamera(true);
        hasGameStarted = false;
        inMenuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);

        if (hasSeenRewardedAd)
        {
            adButton.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            adButton.GetComponent<Button>().enabled = false;
            adButton.GetComponent<Animator>().enabled = false;
            restartButton.GetComponent<Animator>().enabled = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0); // loads whatever scene is at index 0 in build settings
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
             case ShowResult.Finished:
                hasSeenRewardedAd = true;
                StartCoroutine(StartGame(1.5f));
                Debug.Log("The ad was successfully shown");
                break;
             case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end");
                break;
             case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown");
                break;
        }
    }

    public bool IsGamePaused()
    {
        return gameIsPaused;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
