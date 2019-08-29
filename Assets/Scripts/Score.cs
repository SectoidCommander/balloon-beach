using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
	public int score;
    public int highScore;
    public TextMeshProUGUI highScoreUI;
	public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI speedUpUI;
    public float speedUpPromptTimeLimit = 2.0f;
    private float speedUpTime = 0.0f;
    public float speedUpAmount = 0.2f;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        highScore = PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
		scoreUI.text = score.ToString();
        highScoreUI.text = highScore.ToString();
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", score);
        }

        /*if (speedUpUI.IsActive())
        {
            if (speedUpUI.GetComponent<Animation>().)
            {
                speedUpUI.gameObject.SetActive(false);
                speedUpUI.GetComponent<Animation>().Stop();
            }

            if(speedUpTime <= speedUpPromptTimeLimit)
            {
                speedUpTime += Time.deltaTime;
            }
            else
            {
                speedUpUI.gameObject.SetActive(false);
                speedUpTime = 0.0f;
            }
        }*/
    }
	
    public void ScoreUp(int scoreAmount)
    {
        score += scoreAmount;
        if (score != 0 && (score % 10) == 0)
        {
            this.GetComponent<Player>().SpeedUp(speedUpAmount);
            speedUpUI.gameObject.SetActive(false);
            speedUpUI.gameObject.SetActive(true);
            speedUpUI.GetComponent<Animation>().Play();
        }
    }
}