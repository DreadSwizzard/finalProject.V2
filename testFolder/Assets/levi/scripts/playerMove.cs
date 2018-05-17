using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerMove : MonoBehaviour {
    public GameObject magicimage, windimage, forrestimage, undeadimage, earthimage,
        fireimage, waterimage, iceimage, techimage, lightimage, shadowimage, magicorb,
        wind, leafball, acidball, rock, fireball, waterball, icespike, techbomb, lightorb,
        shadoworb, forceorb, activeclass, coinText;
    private GameObject prefab,type;
    public float bulletSpeed = 10f, bulletLifetime = 1.0f, shootDelay = 1.0f,timer=0,speed = 5.0f,
        damage=1.0f, firedamage = 5.0f, waterdamage = 3.0f, lightdamage = 0.5f, winddamage = 2.0f ,
        earthdammage = 2.0f, icedamage = 2.0f, forrestdamage = 2.0f, magicdamage = 1.5f,
        undeaddamage = 3.0f, shadowdamage = 3.5f,techdamage = 8.0f;
    public int currentcase, coinCount, currentClass;
    public bool bronzekey, silverkey, goldkey, diamondkey, platinumkey, bosskey, firemage, icemage, watermage, windmage,
        forrestmage, earthmage, lightmage, necromancer,magition, shadowmancer, technomancer, magic,
        classIsSwitching = false;
    public string magictype = "normal";
    void Start()
    {
        currentClass = currentcase;
        classIsSwitching = true;
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
            Destroy(myCollisionInfo.gameObject);
            bronzekey = true;
        }
        else if (myCollisionInfo.gameObject.name == "silverkey")
        {
            //open silver door
            Destroy(myCollisionInfo.gameObject);
            silverkey = true;
        }
        else if (myCollisionInfo.gameObject.name == "goldkey")
        {
            //open gold door
            Destroy(myCollisionInfo.gameObject);
            goldkey = true;
        }
        else if (myCollisionInfo.gameObject.name == "diamondkey")
        {
            //open diamond door
            Destroy(myCollisionInfo.gameObject);
            diamondkey = true;
        }
        else if (myCollisionInfo.gameObject.name == "platinumkey")
        {
            //open platnum door
            Destroy(myCollisionInfo.gameObject);
            platinumkey = true;
        }
        else if (myCollisionInfo.gameObject.name == "bosskey")
        {
            //open boss door
            Destroy(myCollisionInfo.gameObject);
            bosskey = true;
        }
        else if (myCollisionInfo.gameObject.name == "undeadsym")
        {
            Debug.Log(myCollisionInfo);
            necromancer = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "windsym")
        {
            Debug.Log(myCollisionInfo);
            windmage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "forrestsym")
        {
            Debug.Log(myCollisionInfo);
            forrestmage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "earthsym")
        {
            Debug.Log(myCollisionInfo);
            earthmage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "firessym")
        {
            Debug.Log(myCollisionInfo);
            firemage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "watersym")
        {
            Debug.Log(myCollisionInfo);
            watermage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "icesym")
        {
            Debug.Log(myCollisionInfo);
            icemage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "magicsym")
        {
            Debug.Log(myCollisionInfo);
            magition = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "techsym")
        {
            Debug.Log(myCollisionInfo);
            technomancer = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "lightsym")
        {
            Debug.Log(myCollisionInfo);
            lightmage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if(myCollisionInfo.gameObject.name=="shadowsym")
        {
            Debug.Log(myCollisionInfo);
            shadowmancer = true;
            Destroy(myCollisionInfo.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float classvar = Input.GetAxisRaw("Mouse ScrollWheel");
        if (classvar > 0f)
        {
            currentClass = currentClass + 1;
            classIsSwitching = true;
        }
        else if (classvar<0f)
        {
            currentClass = currentClass - 1;
            
                classIsSwitching = true;
        }
        if (classvar >0f && currentClass >=13)
        {
            currentClass = 1;
            classIsSwitching = true;
        }
        if (classvar<0 && currentClass <=0)
        {
            currentClass = 12;
            classIsSwitching = true;
        }
        if (classIsSwitching == true)
        {       
            switch(currentClass)
            {
                case 0: magictype = "normal";
                    break;
                case 1:if(necromancer==true)
                    {
                        magictype = ("undead");
                        Debug.Log("undead");
                    }
                    break;
                case 2:  if(windmage == true)
                    {
                        magictype = ("wind");
                        Debug.Log("wind");
                    }
                    break;
                case 3: if (forrestmage == true)
                    {
                        magictype = ("forrest");
                        Debug.Log("forrest");
                    }
                    break;
                case 4: if(earthmage == true)
                {
                        magictype = ("earth");
                        Debug.Log("earth");
                }
                    break;
                case 5:if (firemage == true)
                    {
                        magictype = ("fire");
                        Debug.Log("fire");
                    }
                    break;
                case 6:if (watermage==true)
                    {
                        magictype = ("water");
                        Debug.Log("water");
                    }
                    break;
                case 7:   if (icemage==true)
                    {
                        magictype = ("ice");
                        Debug.Log("ice");
                    }
                    break;
                case 8:   if (technomancer==true)
                    {
                        magictype = ("tech");
                        Debug.Log("tech");
                    }
                    break;
                case 9:   if(lightmage==true)
                    {
                        magictype = ("light");
                        Debug.Log("light");
                    }
                    break;
                case 10:if (shadowmancer==true)
                    {
                        magictype = ("shadow");
                        Debug.Log("shadow");
                    }
                    break;
                case 11: if (magition == true)
                    {
                        magictype = "magic";
                        Debug.Log("magic");
                    }
                    break;
                case 12: magictype = ("normal");
                    Debug.Log("normal");
                    break;
            }
          
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 push = new Vector2(horizontal, vertical);
        gameObject.GetComponent<Rigidbody2D>().velocity = push * speed;
        if (Input.GetKeyDown(KeyCode.Alpha9))

        if (Input.GetButtonDown("Fire1"))
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
                Debug.Log("windshoot");
            }
            
            else if (magictype == "forrest")
            {
                type = forrestimage;
                prefab = leafball;
                damage = forrestdamage;
                Debug.Log("forrestshoot");
                //target is restrained temporarily
            }
           
            else if (magictype == "earth")
            {
                type = earthimage;
                prefab = rock;
                damage = earthdammage;
                Debug.Log("earthshoot");
                //ground shakes and enemies are stunned
            }
            else if (magictype == "fire")
            {
                type = fireimage;
                prefab = fireball;
                damage = firedamage;
                Debug.Log("fireshoot");
            } 
            else if (magictype == "undead")
            {
                type = undeadimage;
                prefab = acidball;
                damage = undeaddamage;
            }
            else if (magictype == "water")
            {
                type = waterimage;
                prefab = waterball;
                damage = waterdamage;
                Debug.Log("watershoot");
            }
            else if (magictype == "ice")
            {
                type = iceimage;
                prefab = icespike;
                damage = icedamage;
                Debug.Log("iceshoot");
            }
            else if (magictype == "magic")
            {
                type = magicimage;
                prefab = magicorb;
                damage = magicdamage;
                Debug.Log("magicshoot");
            }
            else if (magictype == "light")
            {
                type = lightimage;
                prefab = lightorb;
                damage = lightdamage;
                Debug.Log("lightshoot");
            }
           
            else if (magictype == "shadow")
            {
                type = shadowimage;
                prefab = shadoworb;
                damage = shadowdamage;
                Debug.Log("shadowshoot");
            }
            else if (magictype == "tech")
            {
                type = techimage;
                prefab = techbomb;
                damage = techdamage;
                Debug.Log("techshoot");
            }
         
        }
    }

}