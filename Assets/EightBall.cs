using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightBall : MonoBehaviour
{
    public GameObject Eball;
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
        if(col.gameObject.tag == "CueBall")
        {
            for(int i = 0; i < 5; i++)
            {
                Instantiate(Eball, transform.position, transform.rotation);
            }
        }
    }
}
