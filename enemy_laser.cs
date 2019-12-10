using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_laser : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Text playerHealth;
    private int scene = 6;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        playerHealth = GameObject.Find("Health").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y < 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(this.gameObject);
            playerHealth.GetComponent<player_health>().health -= 1;
            playerHealth.GetComponent<player_health>().UpdateHealth();
            if(playerHealth.GetComponent<player_health>().health <= 0)
            {
                GameObject.Destroy(collision.gameObject);
                Application.LoadLevel(scene);
            }

        }
    }
}
