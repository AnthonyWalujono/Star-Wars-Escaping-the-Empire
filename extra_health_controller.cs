using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class extra_health_controller : MonoBehaviour
{
    public int health = 0;
    private Rigidbody2D rb;
    private Text playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GameObject.Find("Health").GetComponent<Text>();
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
            playerHealth.GetComponent<player_health>().health += health;
            playerHealth.GetComponent<player_health>().UpdateHealth();

        }
    }
}
