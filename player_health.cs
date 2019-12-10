using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_health : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 10;
    void Start()
    {
        health = PlayerPrefs.GetInt("CurrentHealth");
    }

    public void UpdateHealth()
    {

        Debug.Log("UpdatingHealth");
        GetComponent<Text>().text = "Health: " + health;
        PlayerPrefs.SetInt("CurrentHealth", health);
    }
    public void OnEnable()
    {
        health = PlayerPrefs.GetInt("CurrentHealth");
        UpdateHealth();
    }
    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            health = 0;
        }
    }
}
