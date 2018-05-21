using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class mainmenue : MonoBehaviour {
   
    public void StartGame()
    {
        SceneManager.LoadScene("scene1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void white()
    {
        PlayerPrefs.SetInt("gender", 1);
        //set player male
    }
    public void pink()
    {
        PlayerPrefs.SetInt("gender", 2);
        //set player female
    }
}
