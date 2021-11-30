using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSteal : MonoBehaviour
{
    public bool holdingBall = false;
    public GameObject ball;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision worked");
        if(col.tag == "CueBall")
        {
            if(holdingBall == false)
            {
                Destroy(col.gameObject);
                holdingBall = true;
            }
        }

        if(col.tag == "Stick")
        {
            if(holdingBall == true)
            {
                Vector3 vec = new Vector3(5f,5f,0f);
                Instantiate(ball, transform.position + vec, transform.rotation);
                Invoke("noHold", 5f);
            }
        }
    }

    void noHold()
    {
        holdingBall = false;
    }
}
