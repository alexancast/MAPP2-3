using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {


    public void StartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
