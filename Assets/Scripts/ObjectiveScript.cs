using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveScript : MonoBehaviour
{
    public int randBall;
    public float actionTime = 0;
    public int wave = 1;
    public TextMeshProUGUI waveText;
    public BallShooting shoot;
    public GameObject[] game;
    public GameObject[] gBall;
    public Transform spawnPoint;
    public Transform summon;
    public GameObject eBall;
    public GameObject basic;
    public GameObject googly;
    public GameObject bigBoy;
    public GameObject magic;
    public GameObject dasher;
    public GameObject darkness;
    List<GameObject> ballList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        ballList.Add(basic);
        game = GameObject.FindGameObjectsWithTag("Ball");
    }   

    // Update is called once per frame
    void Update()
    {
        if(Time.time > actionTime)
        {
            game = new GameObject[0];
            game = GameObject.FindGameObjectsWithTag("Ball");
            gBall = GameObject.FindGameObjectsWithTag("gBall");
            actionTime = Time.time;
            actionTime += 5;
            if(game.Length == 0 && gBall.Length == 0)
            {
                wave += 1;
                if(wave == 1)
                {
                    ballList.Add(bigBoy);
                }

                else if(wave == 2)
                {
                    ballList.Add(eBall);
                }

                else if(wave == 4)
                {
                    ballList.Add(googly);
                    ballList.Add(dasher);
                }

                else if(wave == 7)
                {
                    ballList.Add(magic);
                }

                else if(wave == 10)
                {
                    ballList.Add(darkness);
                }
                Spawning(wave);
                waveText.text = "Wave: " + wave;
            }
        }
    }

    public void Spawning(int amount)
    {
        for(int i = 0; i < (amount + 2); i++)
        {
            randBall = Random.Range(0, ballList.Count);
            float randX = Random.Range(-24,24);
            float randY = Random.Range(-8,7);
            summon.position = new Vector3
            (
                spawnPoint.transform.position.x + randX,
                spawnPoint.transform.position.y + randY,
                spawnPoint.transform.position.z
            );
            Instantiate(ballList[randBall], summon.position, summon.rotation);
        }
        shoot.invisible = true;
        Invoke("notInvinsible", 0.5f);
    }

    void notInvinsible()
    {
        shoot.invisible = false;
    }
}
