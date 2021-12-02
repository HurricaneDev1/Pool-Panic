using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firepoint;
    public float actionTime;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        actionTime = Time.time;
        actionTime += 2;
    }

    // Update is called once per frame
    void Update()
    {   
        if(Time.time > actionTime)
        {
            actionTime = Time.time;
            actionTime += 4;
            for(int i = 0; i < 4; i++){
                MagicShot();
            }
        }
    }

    void MagicShot()
    {
        //Using random set's the firepoint objects rotation
        firepoint.transform.eulerAngles = new Vector3
        (
            firepoint.transform.eulerAngles.x,
            firepoint.transform.eulerAngles.y,
            firepoint.transform.eulerAngles.z + 100
        );
        GameObject bull = Instantiate(bullet,firepoint.transform.position,firepoint.transform.rotation);
        Rigidbody2D rig = bull.GetComponent<Rigidbody2D>();
        rig.AddForce(firepoint.transform.up * speed, ForceMode2D.Impulse);
    }
}
