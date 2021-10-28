using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public BallShooting shoot;
    public GameObject Player;
    public Transform spawnPoint;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Ball")
        {
            shoot.ammo ++;
            Destroy(col.gameObject);
        }

        if(col.tag == "Player")
        {
            Invoke("SpawnPlayer", 2.0f);
        }
    }

    void SpawnPlayer()
    {
        Instantiate(Player, spawnPoint.position, spawnPoint.rotation);
    }   
}
