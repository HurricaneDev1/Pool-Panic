using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooting : MonoBehaviour
{
    public int ammo;
    public float moveSpeed;
    Vector2 movement;
    public Camera cam;
    public Rigidbody2D rb;
    public Transform firePoint;
    public GameObject cueBall;
    public float ballSpeed = 20f;
    public bool strongShot = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(ammo > 0)
            {
                Shoot();
                ammo --;
            }
        }
    }

    void Shoot()
    {
        GameObject ball = Instantiate(cueBall,firePoint.position,firePoint.rotation);
        Rigidbody2D rig = ball.GetComponent<Rigidbody2D>();
        if(strongShot == true)
        {
            ballSpeed = 75;
        }
        rig.AddForce(firePoint.up * ballSpeed, ForceMode2D.Impulse);
        ballSpeed = 30f;
        strongShot = false;
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
    }
}
