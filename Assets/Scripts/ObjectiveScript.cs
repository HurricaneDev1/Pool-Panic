using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBjectiveScript : MonoBehaviour
{
    public float actionTime = 0;
    public GameObject[] game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindGameObjectsWithTag("Ball");
    }   

    // Update is called once per frame
    void Update()
    {
        if(Time.time > actionTime)
        {
            game = new GameObject[0];
            game = GameObject.FindGameObjectsWithTag("Ball");
            actionTime = Time.time;
            actionTime += 5;
            if(game.Length == 0)
            {
                Debug.Log("You Win");
            }
        }
    }
}
