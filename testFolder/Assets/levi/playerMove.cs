using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerMove : MonoBehaviour {
    public Image normalimage;
    public Image type;
  public Image magicimage;
    public Image windimage;
    public Image forrestimage;
    public Image undeadimage;
    public Image earthimage;
    public Image fireimage;
    public Image waterimage;
    public Image iceimage;
    public Image techimage;
    public Image lightimage;
    public Image shadowimage;
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
    public GameObject forceorb;
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
    public float earthdammage = 2.0f;
    public float icedamage = 2.0f;
    public float forrestdamage = 2.0f;
    public float magicdamage = 1.5f;
    public float undeaddamage = 0.5f;
    public float shadowdamage = 3.5f;
    public float techdamage = 8.0f;
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
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            magictype = ("wind");
            //Debug.Log("wind");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            magictype = ("undead");
            //Debug.Log("undead");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            magictype = ("earth");
            //Debug.Log("earth");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            magictype = ("fire");
            //Debug.Log("fire);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            magictype = ("water");
            //Debug.Log("water");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            magictype = ("ice");
            //Debug.Log("ice");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            magictype = ("tech");
            //Debug.Log("tech");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9)   )
        {
            magictype = ("light");
            //Debug.Log("light);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            magictype = ("shadow");
            //Debug.Log("shadow");
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
                type = windimage;
                prefab = wind;
                damage = winddamage;
                //knockback
            }
            
            else if (magictype == "forrest")
            {
                type = forrestimage;
                prefab = liefball;
                damage = forrestdamage;
                //target is restrained temporarily
            }
            else if (magictype == "undead")
            {
                type = undeadimage;
                prefab = acidball;
                damage = undeaddamage;
                //when enemy dies it reanimates and fights for you at half health
            }
            else if (magictype == "earth")
            {
                type = earthimage;
                prefab = rock;
                damage = earthdammage;
                //ground shakes and enemies are stunned
            }
            else if (magictype == "fire")
            {
                type = fireimage;
                prefab = fireball;
                damage = firedamage;
            }
            else if (magictype == "water")
            {
                type = waterimage;
                prefab = waterball;
                damage = waterdamage;
            }
            else if (magictype == "ice")
            {
                type = iceimage;
                prefab = icespike;
                damage = icedamage;
            }
            else if (magictype == "magic")
            {
                type = magicimage;
                prefab = magicorb;
                damage = magicdamage;
            }
            else if (magictype == "light")
            {
                type = lightimage;
                prefab = lightorb;
                damage = lightdamage;
            }
           
            else if (magictype == "shadow")
            {
                type = shadowimage;
                prefab = shadoworb;
                damage = shadowdamage;
            }
            else if (magictype == "tech")
            {
                type = techimage;
                prefab = techbomb;
                damage = techdamage;
            }
            else
            {
                type = normalimage;
                prefab = forceorb;
                damage = 1;
               //no special
           
            }
        }
    }

}