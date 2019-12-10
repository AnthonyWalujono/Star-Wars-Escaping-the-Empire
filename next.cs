using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is a button used when the player change from the score scene to the main page. 
public class next : MonoBehaviour
{
    private int level = 0;
    public void LoadScene(int level)
    {
        PlayerPrefs.SetInt("CurrentHealth", 10);
        PlayerPrefs.SetInt("CurrentScore", 0);
        Application.LoadLevel(level);
    }
    // Start is called before the first frame update
}
