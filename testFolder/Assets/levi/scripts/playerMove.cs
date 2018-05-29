using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class playerMove : MonoBehaviour {
    public GameObject male, female, player, invisible, magicimage, windimage, forrestimage, undeadimage, earthimage, normal,
        fireimage, waterimage, iceimage, techimage, lightimage, shadowimage, magicorb,
        wind, leafball, acidball, rock, fireball, waterball, icespike, techbomb, lightorb,
        shadoworb, forceorb, activeclass, coinText, prefab, type;
    public float sprintmod = 75.0f,speeddef = 5.0f, basicenemydmg = 2, keeperdmg=5, enemyprojectileDamage = 5, healthPotion,manaregen= 0.017f,
        maxmana = 20,cost,mana=20,specialcost = 2, tachcost = 1,forrestcost = 1,undeadcost =1,firecost = 1, lightcost=1,icecost = 1, watercost = 1, shadowcost= 1, 
        earthcost=1,magiccost=1,windcost = 1,health = 20, firerad,waterrad,lightrad,windrad,earthrad,icerad,forrestrad,
        magicrad,undeadrad,shadowrad,techrad, radius,bulletSpeed = 10f, bulletLifetime = 1.0f, shootDelay = 1.0f,timer=0,
        speed = 5.0f,damage=1.0f, firedamage = 5.0f, waterdamage = 3.0f, lightdamage = 0.5f, winddamage = 2.0f ,earthdammage = 2.0f, 
        icedamage = 2.0f, forrestdamage = 2.0f, magicdamage = 1.5f, undeaddamage = 3.0f, shadowdamage = 3.5f,techdamage = 8.0f;
    public int specialdmg, currentcase, coinCount, currentClass;
    public bool spellfail, bronzekey, silverkey, goldkey, diamondkey, platinumkey, bosskey, firemage, icemage, watermage, windmage,
        forrestmage, earthmage, lightmage, necromancer,magition, shadowmancer, technomancer, magic, classIsSwitching = false;
    public string magictype = "normal";
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("gender"));
        if (PlayerPrefs.GetInt("gender") == 1)
        {
           
            Instantiate(male, player.transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        /*if (PlayerPrefs.GetInt("gender") == 2)
        {
            player = female;
        } */
        currentClass = currentcase;
        classIsSwitching = true;
        timer = shootDelay;
    }
    // Use this for initialization
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);

    }
        
    void OnCollisionEnter2D(Collision2D myCollisionInfo)
    {
        
        if (myCollisionInfo.gameObject.tag == "coin")
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
            //Debug.Log(myCollisionInfo);
            necromancer = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "windsym")
        {
           // Debug.Log(myCollisionInfo);
            windmage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "forrestsym")
        {
            //Debug.Log(myCollisionInfo);
            forrestmage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "earthsym")
        {
            //Debug.Log(myCollisionInfo);
            earthmage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "firessym")
        {
            //Debug.Log(myCollisionInfo);
            firemage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "watersym")
        {
            //Debug.Log(myCollisionInfo);
            watermage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "icesym")
        {
            //Debug.Log(myCollisionInfo);
            icemage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "magicsym")
        {
            //Debug.Log(myCollisionInfo);
            magition = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "techsym")
        {
            //Debug.Log(myCollisionInfo);
            technomancer = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if (myCollisionInfo.gameObject.name == "lightsym")
        {
            //Debug.Log(myCollisionInfo);
            lightmage = true;
            Destroy(myCollisionInfo.gameObject);
        }
        else if(myCollisionInfo.gameObject.name=="shadowsym")
        {
            //Debug.Log(myCollisionInfo);
            shadowmancer = true;
            Destroy(myCollisionInfo.gameObject);
        }
        if (myCollisionInfo.gameObject.tag == "healthpotion")
            {
            health += healthPotion;
        }
        if (myCollisionInfo.gameObject.tag == "enemyProjectile")
        {
            health -= enemyprojectileDamage;
        }
        if (myCollisionInfo.gameObject.tag == "enemy")
        {
            health -= basicenemydmg;
        }
        if (myCollisionInfo.gameObject.tag == "keeper")
        {
            health -= keeperdmg;
        }

    }
    // Update is called once per frame
    void Update()
    {
        coinText.GetComponent<Text>().text = "coins: " + coinCount;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * sprintmod;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speeddef;
        }
        if (mana <= 0)
        {
            magictype = "normal";
        }
         if (cost > mana)
        {
            spellfail = true;
        }
         else
        {
            spellfail = false;
        }
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
                        type = undeadimage;
                        prefab = acidball;
                        cost = undeadcost;
                        damage = undeaddamage;
                        specialdmg = 15;
                        //              Debug.Log("undead");
                    }
                    break;
                case 2:  if(windmage == true)
                    {
                        magictype = ("wind");
                        type = windimage;
                        prefab = wind;
                        cost = windcost;
                        damage = winddamage;
                        specialdmg = 9;
            //            Debug.Log("wind");
                    }
                    break;
                case 3: if (forrestmage == true)
                    {
                        magictype = ("forrest");
                        type = forrestimage;
                        prefab = leafball;
                        cost = forrestcost;
                        damage = forrestdamage;
              //          Debug.Log("forrest");
                    }
                    break;
                case 4: if(earthmage == true)
                {
                        magictype = ("earth");
                        type = earthimage;
                        prefab = rock;
                        cost = earthcost;
                        damage = earthdammage;
                //        Debug.Log("earth");
                }
                    break;
                case 5:if (firemage == true)
                    {
                        magictype = ("fire");
                        type = fireimage;
                        cost = firecost;
                        prefab = fireball;
                        damage = firedamage;
                  //      Debug.Log("fire");
                    }
                    break;
                case 6:if (watermage==true)
                    {
                        magictype = ("water");
                        type = waterimage;
                        cost = watercost;
                        prefab = waterball;
                        damage = waterdamage;
                    //    Debug.Log("water");
                    }
                    break;
                case 7:   if (icemage==true)
                    {
                        magictype = ("ice");
                        type = iceimage;
                        cost = icecost;
                        prefab = icespike;
                        damage = icedamage;
                        //Debug.Log("ice");
                    }
                    break;
                case 8:   if (technomancer==true)
                    {
                        magictype = ("tech");
                        type = techimage;
                        prefab = techbomb;
                        cost = tachcost;
                        damage = techdamage;
                       // Debug.Log("tech");
                    }
                    break;
                case 9:   if(lightmage==true)
                    {
                        magictype = ("light");
                        type = lightimage;
                        prefab = lightorb;
                        cost = lightcost;
                        damage = lightdamage;
                       // Debug.Log("light");
                    }
                    break;
                case 10:if (shadowmancer==true)
                    {
                        magictype = ("shadow");
                        cost = shadowcost;
                        type = shadowimage;
                        prefab = shadoworb;
                        damage = shadowdamage;
                       // Debug.Log("shadow");
                    }
                    break;
                case 11: if (magition == true)
                    {
                        magictype = "magic";
                        type = magicimage;
                        cost = magiccost;
                        prefab = magicorb;
                        damage = magicdamage;
                     //   Debug.Log("magic");
                    }
                    break;
                case 12: magictype = ("normal");
                    type = normal;
                    prefab = forceorb;
                    damage = 1;
                    cost = 0;
                   // Debug.Log("normal");
                    break;
            }
          
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 push = new Vector2(horizontal, vertical);
        gameObject.GetComponent<Rigidbody2D>().velocity = push * speed;

        if (Input.GetButtonDown("Fire1") && spellfail == false || Input.GetButtonDown("Fire1") && magictype == "normal")
            {
            mana -= cost;
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
            if (Input.GetButtonDown("Fire2")&&spellfail == false)
            {
            damage = specialdmg;
            if (magictype == "wind")
            {
                radius = windrad;
                //knockback
                mana -= specialcost + windcost;
              
            }
            else if (magictype == "undead")
            {
                mana -= specialcost + undeadcost;
         //reanimate enemy to fight for you
         radius = undeadrad;
            }
            else if (magictype == "forrest")
            {
                //regen health
                health += 5;
                radius = forrestrad;
                mana -= specialcost + forrestcost;
            }
            else if(magictype =="light")
            {
                mana -= specialcost + lightcost;
             radius = lightrad;
               //blindes enemies / lights up dark areas/
            }
            else if (magictype == "fire")
            {
                mana -= specialcost + firecost;
               radius = firerad;
             //enemies in area are on fire
            }
            else if (magictype == "shadow")
            {
                mana -= specialcost + shadowcost;
               radius = shadowrad;
             //enemy hit attacks other enemies
            }
            else if(magictype == "earth")
            {
                mana -= specialcost + earthcost;
               radius = earthrad;
                //earthquake/enemies stunned
            }
            else if (magictype == "ice")
            {
                mana -= specialcost + icecost;
               //enemies are frozen
               radius = icerad;
            }
            else if (magictype == "tech")
            {
                mana -= specialcost + tachcost;
               //enemies are stunned/ electrocuted
               radius = techrad;
            }
            else if (magictype == "magic")
            {
                mana -= specialcost + magiccost;
               radius = magicrad;
                //player is invisible to enemies
                Instantiate(invisible, player.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if(magictype  == "water")
            {
                mana -= specialcost + watercost;
              radius = waterrad;
               //wave pushes enemies away
            }
               
            }
    if (mana < maxmana)
        {
            mana += manaregen;
        }
    }

}