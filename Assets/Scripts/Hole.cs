using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Hole : MonoBehaviour
{
    public GameObject Player;
    public Transform spawnPoint;
    public ObjectiveScript ob;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "CueBall")
        {
            Destroy(col.gameObject);
            BallShooting[] objects = FindObjectsOfType<BallShooting>();
            objects[0].ammo ++;
            ob.Spawning(-1);
        }

        if(col.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if(col.tag == "Ball" || col.tag == "gBall" || col.tag == "Bullet")
        {
            Destroy(col.gameObject);
        }

    }
}
