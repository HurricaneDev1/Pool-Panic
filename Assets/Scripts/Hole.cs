using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Hole : MonoBehaviour
{
    public GameObject Player;
    public Transform spawnPoint;
    public ObjectiveScript ob;
    public float actionTime;
    public BallShooting ball;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "CueBall")
        {
            Destroy(col.gameObject);
            BallShooting[] objects = FindObjectsOfType<BallShooting>();
            objects[0].ammo ++;
            ob.Spawning(-1);
        }

        if(col.tag == "Ball" || col.tag == "gBall" || col.tag == "Bullet")
        {
            Destroy(col.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D co)
    {
        if(co.tag == "Player")
        {
            if(Time.time > actionTime)
            {
                actionTime = Time.time;
                actionTime += 0.2f;
                ball.health -= 1;
            }
        }
    }
}
