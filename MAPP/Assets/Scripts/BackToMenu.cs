using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

	void Update () {
		if(Input.GetKey(KeyCode.Escape))
        {
            PlayerPrefs.SetFloat("xPos", transform.position.x);
            PlayerPrefs.SetFloat("yPos", transform.position.y);
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
	}
}
