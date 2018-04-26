using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour {

    public Text highScore;

	void Update () {
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString() + "m";
	}

}
