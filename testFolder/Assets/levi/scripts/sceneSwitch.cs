using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneSwitch : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D myCollisionInfo)
    {
        if (myCollisionInfo.gameObject.tag == "levelEnd" && PlayerPrefs.GetInt("levelname") == 1)
        {
            SceneManager.LoadScene("Fields of Ryandar");
        }
        if (myCollisionInfo.gameObject.tag == "levelEnd" && PlayerPrefs.GetInt("levelname") == 2)
        {
            SceneManager.LoadScene("The Alter");
        }
        if (myCollisionInfo.gameObject.tag == "levelEnd" && PlayerPrefs.GetInt("levelname") == 3)
        {
            SceneManager.LoadScene("Ryandar Forrest");
        }
    }


}
