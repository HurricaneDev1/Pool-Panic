using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject Player;
    public Transform spawnPoint;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "CueBall")
        {
            Destroy(col.gameObject);
            BallShooting[] objects = FindObjectsOfType<BallShooting>();
            objects[0].ammo ++;
        }

        if(col.tag == "Player")
        {
            Invoke("SpawnPlayer", 2.0f);
            Destroy(col.gameObject);
        }

        if(col.tag == "Ball")
        {
            Destroy(col.gameObject);
        }
    }

    void SpawnPlayer()
    {
        Instantiate(Player, spawnPoint.position, spawnPoint.rotation);
    }   
}
