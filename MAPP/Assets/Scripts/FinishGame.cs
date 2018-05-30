using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{

    public bool gameIsWon = false;
    public GameObject winPanel;


    void Update()
    {



    }


    public bool isWon()
    {

        return gameIsWon;
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Player")
        {
            gameIsWon = true;
            winPanel.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            gameIsWon = false;
            winPanel.SetActive(false);
        }
    }
}
