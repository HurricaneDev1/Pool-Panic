using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BallShooting : MonoBehaviour
{
    public float goneTime;
    GameObject ballG;
    public bool invisible = false;
    public int ammo;
    public float moveSpeed;
    Vector2 movement;
    public Camera cam;
    public Transform firePoint;
    public GameObject cueBall;
    public float ballSpeed = 20f;
    public bool strongShot = false;
    public int health = 6;
    public int numOfHearts = 10;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptySprite;
    public Image ball;
    // Update is called once per frame
    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health){
                hearts[i].sprite = fullHeart;
            }
            else{
                hearts[i].sprite = emptySprite;
            }

            if(i < numOfHearts){
                hearts[i].enabled = true;
            }
            else{
                hearts[i].enabled = false;
            }
        }
        if(ammo > 0){
            ball.enabled = true;
        }
        else{
            ball.enabled = false;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            if(ammo > 0)
            {
                Shoot();
                ammo --;
            }
        }

        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(ammo < 1)
            {
                if(Time.time > goneTime)
                {
                    Destroy(ballG);
                    ammo ++;
                }
            }

            else
            {
                goneTime = Time.time;
                goneTime += 5;
            }
        }
    }

    void Shoot()
    {
        ballG = Instantiate(cueBall,firePoint.position,firePoint.rotation);
        Rigidbody2D rig = ballG.GetComponent<Rigidbody2D>();
        if(strongShot == true)
        {
            ballSpeed = 75;
        }
        rig.AddForce(firePoint.up * ballSpeed, ForceMode2D.Impulse);
        ballSpeed = 30f;
        strongShot = false;
        goneTime = Time.time;
        goneTime += 5;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "CueBall")
        {
            ammo ++;
            Destroy(col.gameObject);
        }

        if(col.tag == "powerUp")
        {
            strongShot = true;
            Destroy(col.gameObject);
        }

        if(col.tag == "Ball" || col.tag == "gBall" || col.tag == "Bullet")
        {
            if(invisible == false)
            {
                health -= 1;
            }
    
            if(health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}
