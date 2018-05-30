using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgress : MonoBehaviour {

    public Vector2 pos;

	public void ResetAll()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetFloat("xPos", pos.x);
        PlayerPrefs.SetFloat("yPos", pos.y);

    }
}
