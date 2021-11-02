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
    Vector2 mousePos;
    public Transform firePoint;
    public GameObject cueBall;
    public float ballSpeed = 20f;
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
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        GameObject ball = Instantiate(cueBall,firePoint.position,firePoint.rotation);
        Rigidbody2D rig = ball.GetComponent<Rigidbody2D>();
        rig.AddForce(firePoint.up * ballSpeed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "CueBall")
        {
            ammo ++;
            Destroy(col.gameObject);
        }
    }
}
