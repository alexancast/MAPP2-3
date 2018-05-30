using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgress : MonoBehaviour {

    public Vector2 pos;

	public void ResetAll()
    {

        PlayerPrefs.SetInt("elapsedSecs", 0);
        PlayerPrefs.SetInt("elapsedMins", 0);
        PlayerPrefs.SetInt("elapsedHours", 0);
        PlayerPrefs.SetFloat("timeElapsed", 0);
        
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetFloat("xPos", pos.x);
        PlayerPrefs.SetFloat("yPos", pos.y);

    }
}
