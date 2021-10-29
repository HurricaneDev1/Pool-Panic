using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject Player;
    public Transform spawnPoint;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Ball")
        {
            Destroy(col.gameObject);
            Player.GetComponentInChildren<BallShooting>().ammo ++;
        }

        if(col.tag == "Player")
        {
            Invoke("SpawnPlayer", 2.0f);
            Destroy(col.gameObject);
        }
    }

    void SpawnPlayer()
    {
        Instantiate(Player, spawnPoint.position, spawnPoint.rotation);
    }   
}
