using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class female : MonoBehaviour {
    public GameObject male, famale, player;
	// Use this for initialization
	void Start () {
        Debug.Log(PlayerPrefs.GetInt("gender"));
        if (PlayerPrefs.GetInt("gender") == 1)
        {
            Instantiate(male, player.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (PlayerPrefs.GetInt("gender") == 2)
        {
            player = famale;
        }
    }
	
	
}
