using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenue : MonoBehaviour {
    public GameObject charictor;
    public GameObject male;
    public GameObject female;
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
        charictor = male;
    }
    public void pink()
    {
        charictor = female;
    }
}
