using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float nextFireTime = 0;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pull();
    }

    Vector2 toUnitVector2(Vector3 vec){
        Vector2 unitVector = new Vector2(vec.x, vec.y);
        unitVector.Normalize();
        return unitVector;
    }

    void Pull(){
        float cooldownTime = 0.1f;
        if(Time.time > nextFireTime)
        {
            float launchForce = 1000;
            AttackInRadius(false, launchForce, attackRange);
            nextFireTime = Time.time + cooldownTime;
        }
    }

    Vector2 getLaunchDirection(bool push, float launchVelocity, Vector3 playerPosition, Vector3 enemyPosition){Vector3 finalForm;
        // Enemy - Player = Away From You
        // Player - Enemy = Towards You
        if(push){
            finalForm = enemyPosition - playerPosition;
        }
        else{
            finalForm = playerPosition - enemyPosition;
        }
        Vector2 launchForce = toUnitVector2(finalForm);
        launchForce = launchForce * launchVelocity;
        return launchForce;
    }

    void AttackInRadius(bool push, float launchVelocity, float attackRadius){
        // The radius is determined by attackRadius.
        // The middle of the circle is attackPoint.
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.transform.position, attackRadius);
        foreach(Collider2D enemy in hitEnemies){

            // Gets the transform and rigidbody of targeted enemies.
            if(enemy.tag == "Ball")
            {
                Transform enemyForm = enemy.GetComponent<Transform>();
                Rigidbody2D rig = enemy.GetComponent<Rigidbody2D>();

                // Applies a launch force to the enemy based off of your level.
                // The launch force is away from you, because it is Enemy - Player.
                Vector2 launchForce = getLaunchDirection(push, launchVelocity, this.transform.position, enemyForm.position);
                rig.AddForce(launchForce);
            }
        }
    }

}
