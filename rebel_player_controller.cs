using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This code controls players movements
public class rebel_player_controller : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public GameObject laser;
    public GameObject laser2;
    private Text playerHealth;
    private int scene = 6;
    private AudioSource shootSound;
    public bool canShootRight = true;
    public bool canShootLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GameObject.Find("Health").GetComponent<Text>();
        shootSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();

        //This kills the player and it is a game over when player falls below camera
        if (Camera.main.WorldToViewportPoint(transform.position).y < 0)
        {
            Destroy(this.gameObject);
            Application.LoadLevel(scene);
        }
    }

    //This controls the players movements
    void Move()
    {
        Vector3 characterScale = transform.localScale;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(speed * -1, 0f);
            characterScale.x = -3;
            canShootLeft = true;
            canShootRight = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, 0f);
            characterScale.x = 3;
            canShootRight = true;
            canShootLeft = false;

        }
        transform.localScale = characterScale;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0f, speed * 5);
        }
    }
    void Shoot()
    {
        //Player Shoots Right
        if (Input.GetKeyDown(KeyCode.S) && canShootRight)
        {
            shootSound.Play();
            GameObject.Instantiate(laser, transform.position, transform.rotation);
        }
        if(Input.GetKeyDown(KeyCode.A) && canShootLeft)
        {
            shootSound.Play();
            GameObject.Instantiate(laser2, transform.position, transform.rotation);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            playerHealth.GetComponent<player_health>().health -= 1;
            playerHealth.GetComponent<player_health>().UpdateHealth();
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            playerHealth.GetComponent<player_health>().health -= 1;
            playerHealth.GetComponent<player_health>().UpdateHealth();
        }

    }
}
