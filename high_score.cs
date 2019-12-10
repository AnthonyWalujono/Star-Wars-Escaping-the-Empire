using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//updates high score but not the high score text
public class high_score : MonoBehaviour
{
    private Text playerScore;
    private int highScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = GameObject.Find("Score").GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("CurrentHighScore");

    }
    public void updateHighScore()
    {
        Debug.Log("UpdatingScore");
        if (playerScore.GetComponent<score_status>().score > highScore)
        {
            highScore += playerScore.GetComponent<score_status>().score;
            GetComponent<Text>().text = "High Score: " + highScore;
            PlayerPrefs.SetInt("CurrentHighScore", highScore);
        }

    }
    public void OnEnable()
    {
        highScore = PlayerPrefs.GetInt("CurrentHighScore");
        updateHighScore();

    }

    // Update is called once per frame
    void Update()
    {
        if (highScore < 0)
        {
            highScore = 0;
        }
    }

}
