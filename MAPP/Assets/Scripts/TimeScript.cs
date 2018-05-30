using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{

    public float timeElapsed = 0;
    private int elapsedSecs;
    private int elapsedMins;
    private int elapsedHours;
    public Text text;
    private GameObject finishGame;



    void Start()
    {

        finishGame = GameObject.Find("FinishGame");
        elapsedSecs = PlayerPrefs.GetInt("elapsedSecs");
        elapsedMins = PlayerPrefs.GetInt("elapsedMins");
        elapsedHours = PlayerPrefs.GetInt("elapsedHours");
        timeElapsed = PlayerPrefs.GetFloat("timeElapsed");

    }



    void FixedUpdate()
    {

        if (!finishGame.GetComponent<FinishGame>().isWon() && GameObject.Find("CountdownText") == null)
        {
            timeElapsed += Time.deltaTime;
        }
        increaseSecs();
        increaseMin();
        increaseHours();
        setText(elapsedHours, elapsedMins, elapsedSecs);
        saveTime();

    }

    public void increaseSecs()
    {

        elapsedSecs = (int)Mathf.Round(timeElapsed);

    }


    public void increaseMin()
    {

        if (elapsedSecs >= 60)
        {

            elapsedMins += 1;
            elapsedSecs = 0;
            timeElapsed = 0;
        }

    }



    public void increaseHours()
    {

        if (elapsedMins >= 60)
        {

            elapsedHours += 1;
            elapsedMins = 0;

        }
    }



    public void saveTime()
    {

        PlayerPrefs.SetInt("elapsedSecs", elapsedSecs);
        PlayerPrefs.SetInt("elapsedMins", elapsedMins);
        PlayerPrefs.SetInt("elapsedHours", elapsedHours);
        PlayerPrefs.SetFloat("timeElapsed", timeElapsed);
    }


    public void setText(int hours, int mins, int secs)
    {

        text.text = "Time: " + hours + ":" + mins + ":" + secs;

    }

    public string getTime()
    {

        return elapsedHours + ":" + elapsedMins + ":" + elapsedSecs;
    }


}