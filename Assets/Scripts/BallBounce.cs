using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {   
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, col.contacts[0].normal);

        if(col.gameObject.tag != "Ball")
        {
            rb.velocity = direction * Mathf.Max(speed,0f);
        }

        if(col.gameObject.tag == "Ball")
        {
            Rigidbody2D rig = col.gameObject.GetComponent<Rigidbody2D>();
            if(this.tag == "CueBall")
            {
                rig.AddForce(speed * direction * -65f);
            }
            else{
                rig.AddForce(speed * direction * -45f);
            }
        }

        if(col.gameObject.tag == "gBall")
        {
            Rigidbody2D rig = col.gameObject.GetComponent<Rigidbody2D>();
            rig.AddForce(speed * direction * 45f);
        }
    }
}
