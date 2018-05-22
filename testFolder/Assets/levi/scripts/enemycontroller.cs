using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class enemycontroller : MonoBehaviour {
    public GameObject male, female, target;
    public float chaseSpeed = 2.0f, chaseTriggerDistance = 3.0f, paceDistance = 3.0f;
    private Vector3 startPosition;
    private Vector2 chaseDirection;
    private bool home = true;
    public Vector3 paceDirection = new Vector3(0f, 0f, 0f);
    public bool playerInVisible, isUndead, maleexists,femaleexists= false;
    // Use this for initialization
    void Start()
    {
        //get the spawn position so we know how to get home
        startPosition = transform.position;
           
    }

    // Update is called once per frame
    void Update()
    {
        if (male = null)
        {
            femaleexists = true;
        }
        else
        {
            maleexists = true;
        }
        if (maleexists == true)
        {
            Vector3 malePosition = male.transform.position;
            Vector2 chaseDirection = new Vector2(malePosition.x - transform.position.x,
                                               malePosition.y - transform.position.y);
        }
           else
        {
            Vector3 femalePosition = male.transform.position;
            Vector2 chaseDirection = new Vector2(femalePosition.x - transform.position.x,
                                               femalePosition.y - transform.position.y);
        }
        
        if (chaseDirection.magnitude < chaseTriggerDistance)
        {
            //player gets too close to the enemy
            home = false;
            chaseDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
        }
        else if (home == false)
        {
            Vector2 homeDirection = new Vector2(startPosition.x - transform.position.x,
                                        startPosition.y - transform.position.y);
            if (homeDirection.magnitude < 0.3f)
            {
                //we've arrived home
                home = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            else
            {
                //go home
                homeDirection.Normalize();
                GetComponent<Rigidbody2D>().velocity = homeDirection * chaseSpeed;
            }
        }
        else
        {
            Vector3 displacement = transform.position - startPosition;
            float distanceFromStart = displacement.magnitude;
            if (distanceFromStart >= paceDistance)
            {
                //do stuff, we've gone too far
                paceDirection = -displacement;
            }
            paceDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = paceDirection * chaseSpeed;

        }
       
        if (isUndead == true)
        {
            //attack for player
            
           
        }

    }

}
