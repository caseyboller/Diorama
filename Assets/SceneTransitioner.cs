using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }    
    
    public void ToSakura()
    {
        SceneManager.LoadScene("Sakura");
    }

    public void ToTorii()
    {
        SceneManager.LoadScene("Torii");
    }
}
