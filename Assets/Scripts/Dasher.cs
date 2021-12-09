using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasher : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rig;
    public double actionTime = 0;
    public Vector3 direction;
    public int movespeed = 100;
    public GameObject[] play;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
        actionTime = Time.time + 2;
    }

    // Update is called once per frame
    void Update()
    {
        play = new GameObject[0];
        play = GameObject.FindGameObjectsWithTag("Player");

        if(play.Length != 0)
        {
            player = play[0].GetComponent<Transform>();
            direction = player.position - transform.position;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        rig.rotation = angle;

        if(Time.time > actionTime)
        {
            rig.rotation = angle;
            actionTime = Time.time;
            actionTime += 4;
            rig.AddForce(direction * 3000);
        }
    }
}
