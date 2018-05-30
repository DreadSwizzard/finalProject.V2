using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class enemycontroller : MonoBehaviour {
    public GameObject male, female, target,prefab,spell;
    public float bulletSpeed = 10f, bulletLifetime = 1.0f, shootDelay = 1.0f,timer=0,
        chaseSpeed = 2.0f, chaseTriggerDistance = 3.0f, paceDistance = 3.0f;
    private Vector3 startPosition;
    private Vector2 chaseDirection;
    private bool home = true;
    public Vector3 paceDirection = new Vector3(0f, 0f, 0f);
    public bool playerInVisible, isUndead;
    // Use this for initialization
    void Start()
    {
        //get the spawn position so we know how to get home
        startPosition = transform.position;
        timer = shootDelay;
        if (PlayerPrefs.GetInt("gender") == 1)
        {
            target = male;
            female = male;
        }
        
       else
        {
            target = female;
            male = female;
        }
    }

    // Update is called once per frame
    void Update()
    {
      
         
            Vector3 playerPosition = target.transform.position;
            Vector2 chaseDirection = new Vector2(playerPosition.x - transform.position.x,
                                               playerPosition.y - transform.position.y);

        if (gameObject.name == "archer")
        {
            Debug.Log("shoot");
            var mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 shootDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            shootDirection.Normalize();
            Vector3 spawnPosition = transform.position;
            spawnPosition.x += shootDirection.x * 0.2f;
            spawnPosition.y += shootDirection.y * 0.2f;
            GameObject bullet = (GameObject)Instantiate(prefab, spawnPosition, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
            Destroy(bullet, bulletLifetime);
            timer = 0;
        }
        if (gameObject.name == "mage")
        {
            prefab = spell;
            Debug.Log("shoot");
            var mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 shootDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            shootDirection.Normalize();
            Vector3 spawnPosition = transform.position;
            spawnPosition.x += shootDirection.x * 0.2f;
            spawnPosition.y += shootDirection.y * 0.2f;
            GameObject bullet = (GameObject)Instantiate(prefab, spawnPosition, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
            Destroy(bullet, bulletLifetime);
            timer = 0;
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
