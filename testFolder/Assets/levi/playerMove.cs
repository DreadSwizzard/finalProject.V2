using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerMove : MonoBehaviour {
    public float speed = 5.0f;
    public int coinCount;
    bool bronzekey = false;
    bool silverkey = false;
    bool goldkey = false;
    bool diamondkey = false;
    bool platinumkey = false;
    bool bosskey = false;
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
void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 push = new Vector2(horizontal, vertical);
        gameObject.GetComponent<Rigidbody2D>().velocity = push * speed;
        if (Input.GetButtonDown = ("Fire1"))
        {
            //raycast
        }
    }
}
