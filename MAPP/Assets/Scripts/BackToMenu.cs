using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

    private Rigidbody2D rgd2d;

    private void Start()
    {
        rgd2d = GetComponent<Rigidbody2D>();
    }

    void Update () {
		if(Input.GetKey(KeyCode.Escape))
        {
            PlayerPrefs.SetFloat("xPos", transform.position.x);
            PlayerPrefs.SetFloat("yPos", transform.position.y);
            PlayerPrefs.SetFloat("xVel", rgd2d.velocity.x);
            PlayerPrefs.SetFloat("yVel", rgd2d.velocity.x);

            GetComponent<PlayerController>().countdownDone = false;

            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
	}
}
