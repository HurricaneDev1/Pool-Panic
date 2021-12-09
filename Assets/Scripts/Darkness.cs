using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    public GameObject blackHole;
    public float actionTime;
    private GameObject hole;
    // Start is called before the first frame update
    void Start()
    {
        actionTime = Time.time;
        actionTime += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > actionTime)
        {
            actionTime = Time.time;
            actionTime += 4;
            hole = Instantiate(blackHole, transform.position, transform.rotation);
            Invoke("destroyHole", 3.5f);
        }
    }

    void destroyHole()
    {
        Destroy(hole);
    }
}
