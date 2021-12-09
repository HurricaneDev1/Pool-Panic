using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firepoint;
    public float actionTime;
    public float speed = 5;
    Collider2D col;
    List<GameObject> bullets = new List<GameObject>();
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
            actionTime += 5;
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
        col = bull.gameObject.GetComponent<Collider2D>();
        col.isTrigger = true;
        Rigidbody2D rig = bull.GetComponent<Rigidbody2D>();
        rig.AddForce(firepoint.transform.up * speed, ForceMode2D.Impulse);
        bullets.Add(bull);
        Invoke("makeTrigger", 0.3f);
        Invoke("clearBullets", 4.5f);
    }

    void makeTrigger()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            col = bullets[i].gameObject.GetComponent<Collider2D>();
            col.isTrigger = false;  
        }
    }

    void clearBullets()
    {
        for(int i = 0; i < bullets.Count; i++)
        {
            if(bullets[i] != null)
            {
                Destroy(bullets[i]);
            }
        }
        bullets.Clear();
    }
}
