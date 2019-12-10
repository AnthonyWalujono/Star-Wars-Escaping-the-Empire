using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//updates the high score text
public class highscore_status : MonoBehaviour
{
    public int score = 0;
    private int highScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("CurrentScore");
    }
    public void UpdateScore()
    {
        Debug.Log("UpdatingScore");
        //GetComponent<Text>().text = "Score: " + score;
        PlayerPrefs.SetInt("CurrentScore", score);
        GetComponent<Text>().text = "High Score: " + highScore;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("CurrentHighScore", highScore);
        }
    }

    public void OnEnable()
    {
        score = PlayerPrefs.GetInt("CurrentScore");
        highScore = PlayerPrefs.GetInt("CurrentHighScore");
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
    }
}
