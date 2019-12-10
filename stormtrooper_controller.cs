using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls enemies movements
public class stormtrooper_controller : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private float laser_timer;
    private float max_laser_timer;
    public float minTimer = 5f;
    public float maxTimer = 25f;
    public GameObject laser;
    public bool canFireLasers = true;
    private AudioSource enemyfireSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);

        laser_timer = 0;
        max_laser_timer = Random.Range(minTimer, maxTimer);
        enemyfireSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canFireLasers)
        {
            StartCoroutine("FireLaser");
            enemyfireSound.Play();
        }
        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
        if (Camera.main.WorldToViewportPoint(transform.position).y < 0)
        {
            Destroy(this.gameObject);
        }

    }
    IEnumerator FireLaser()
    {
        if (laser_timer >= max_laser_timer)
        {
            SpawnLaser();
            max_laser_timer = Random.Range(5f, 12f);
            laser_timer = 0;
        }
        laser_timer += 0.1f;
        yield return new WaitForSeconds(0.1f);
    }
    //stormtroopers can shoot eventhough they move position
    void SpawnLaser()
    {
        Vector3 spawnPoint = transform.position;
        GameObject.Instantiate(laser, spawnPoint, transform.rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            speed *= -1;
        }
    }
}
