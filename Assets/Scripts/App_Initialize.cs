using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App_Initialize : MonoBehaviour
{
    public GameObject inMenuUI;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject player;
    public GameObject mainCamera;
    private bool hasGameStarted = false;

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
        player.GetComponent<Player>().SetFrozen(true);

        mainCamera.GetComponent<CameraFollow>().FreezeCamera(true);

        hasGameStarted = true;
        inMenuUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
    }

    IEnumerator StartGame(float waitTime)
    {
        inMenuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(true);
        gameOverUI.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(waitTime);

        mainCamera.GetComponent<CameraFollow>().FreezeCamera(false);
        player.GetComponent<Player>().SetFrozen(false);
    }

    public void GameOver()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        mainCamera.GetComponent<CameraFollow>().FreezeCamera(true);
        hasGameStarted = false;
        inMenuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0); // loads whatever scene is at index 0 in build settings
    }

    public void ShowAd()
    {
        // #FIX LATER
        StartCoroutine(StartGame(1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
