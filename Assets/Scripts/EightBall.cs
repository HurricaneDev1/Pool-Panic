using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightBall : MonoBehaviour
{
    public GameObject Eball;
    public double actionTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(Time.time > actionTime)
        {
            actionTime = Time.time;
            actionTime += 0.2;
            if(col.gameObject.tag == "CueBall")
            {
                Instantiate(Eball, transform.position, transform.rotation);
            }
        }
    }
}
