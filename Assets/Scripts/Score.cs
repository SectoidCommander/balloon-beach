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
    }
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Collider is working");
		if(other.gameObject.tag == "scoreup")
		{
			score++;
		}
	}
}
