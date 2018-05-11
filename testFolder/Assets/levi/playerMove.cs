using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerMove : MonoBehaviour {
    public GameObject magicorb;
    public GameObject wind;
    public GameObject liefball;
    public GameObject acidball;
    public GameObject rock;
    public GameObject fireball;
    public GameObject waterball;
    public GameObject icespike;
    public GameObject techbomb;
    public GameObject lightorb;
    public GameObject shadoworb;
    private GameObject prefab;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 1.0f;
    public float shootDelay = 1.0f;
    public float timer = 0;
    public float speed = 5.0f;
    public float damage = 1.0f;
    public float firedamage = 5.0f;
    public float waterdamage = 3.0f;
    public float lightdamage = 0.5f;
    public float winddamage = 2.0f;
    public float lightningdamage = 1.5f;
    public float icedamage = 2.0f;
    public float forrestdamage = 2.0f;
    public float magicdamage = 1.5f;
    public float undeaddamage = 0.5f;
    public float shadowdamage = 3.5f;
    public int coinCount;
    bool bronzekey = false;
    bool silverkey = false;
    bool goldkey = false;
    bool diamondkey = false;
    bool platinumkey = false;
    bool bosskey = false;
    bool firemage = false;
    bool icemage = false;
    bool watermage = false;
    bool windmage = false;
    bool lighteningmage = false;
    bool forrestmage = false;
    bool earthmage = false;
    bool lightmage = false;
    bool necromancer = false;
    bool shadowmancer = false;
    bool magic = false;
    public string magictype = "normal";
    public GameObject coinText;
    void Start()
    {
        timer = shootDelay;
    }

    // Use this for initialization
    void OnCollisionEnter2D(Collision2D myCollisionInfo)
    {
        if (myCollisionInfo.gameObject.name == "Coin")
        {
            //destroy the coin
            Destroy(myCollisionInfo.gameObject);
            coinCount++;
        }
        if (myCollisionInfo.gameObject.name == "bronzekey")
        {
            //open bronze door
            bronzekey = true;
        }
        else if (myCollisionInfo.gameObject.name == "silverkey")
        {
            //open silver door
            silverkey = true;
        }
        else if (myCollisionInfo.gameObject.name == "goldkey")
        {
            //open gold door
            goldkey = true;
        }
        else if (myCollisionInfo.gameObject.name == "diamondkey")
        {
            //open diamond door
            diamondkey = true;
        }
        else if (myCollisionInfo.gameObject.name == "platinumkey")
        {
            //open platnum door
            platinumkey = true;
        }
        else if (myCollisionInfo.gameObject.name == "bosskey")
        {
            //open boss door
            bosskey = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 push = new Vector2(horizontal, vertical);
        gameObject.GetComponent<Rigidbody2D>().velocity = push * speed;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            magictype = ("normal");
            //Debug.Log("uno");
        }

    

    
    
        if (Input.GetButtonDown("fire1"))
            {
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
            if (magictype == "wind")
            {
                prefab = wind;
                damage = 2;
                //knockback
            }
            
            else if (magictype == "forrest")
            {
                prefab = liefball;
                damage = 2;
                //target is restrained temporarily
            }
            else if (magictype == "undead")
            {
                prefab = acidball;
                damage = 3;
                //when enemy dies it reanimates and fights for you at half health
            }
            else if (magictype == "earth")
            {
                prefab = rock;
                damage = 2;
                //ground shakes and enemies are stunned
            }
            else if (magictype == "fire")
            {

            }
            else if (magictype == "water")
            {

            }
            else if (magictype == "ice")
            {

            }
            else if (magictype == "magic")
            {

            }
            else if (magictype == "light")
            {

            }
            else if (magictype == "light")
            {

            }
            else if (magictype == "shadow")
            {

            }
            else if (magictype == "tech")
            {

            }
            else
            {
                //no special
                damage = 1;
            }
        }
    }

}