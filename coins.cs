using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Coins that player collect and the function when player touches them
public class Coins : MonoBehaviour
{
    public int points = 0;
    private Rigidbody2D rb;
    private Text playerScore;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerScore = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(this.gameObject);
            playerScore.GetComponent<score_status>().score += points;
            playerScore.GetComponent<score_status>().UpdateScore();
        }
    }
}
