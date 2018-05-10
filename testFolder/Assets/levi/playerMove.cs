using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerMove : MonoBehaviour {
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

            //Debug.Log("uno");
        }

    }
public void shoot()
    {
          if (magictype == "normal")
        {       

        }
    }
   public void normal()
    {
        //no ability does minimal damage to enemies
        damage = 1.0f;
    }
    public void fire()
    {
        //special ability 
        //fireball 
        damage = firedamage;
    }


}
