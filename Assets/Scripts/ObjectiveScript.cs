using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveScript : MonoBehaviour
{
    public float actionTime = 0;
    public int wave = 1;
    public TextMeshProUGUI waveText;
    public GameObject[] game;
    public Transform spawnPoint;
    public Transform summon;
    public GameObject eBall;
    public GameObject basic;
    public GameObject robber;
    public GameObject bigBoy;
    public GameObject magic;
    public GameObject dasher;
    List<GameObject> ballList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        ballList.Add(eBall);
        ballList.Add(basic);
        ballList.Add(robber);
        ballList.Add(bigBoy);
        ballList.Add(magic);
        ballList.Add(dasher);
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
                for(int i = 0; i < (wave + 5); i++){
                    int randBall = Random.Range(0, ballList.Count);
                    Spawning(ballList[randBall]);
                }
                wave += 1;
                waveText.text = "Wave: " + wave;
            }
        }
    }

    void Spawning(GameObject summoned)
    {
        float randX = Random.Range(-25,25);
        float randY = Random.Range(-9,8);
        summon.position = new Vector3
        (
            spawnPoint.transform.position.x + randX,
            spawnPoint.transform.position.y + randY,
            spawnPoint.transform.position.z
        );
        Instantiate(summoned, summon.position, summon.rotation);
    }
}
