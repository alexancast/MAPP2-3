using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour {
	
	private GameObject camera;

	void Start () {

		camera = GameObject.Find ("Main Camera");
		
	}

	void Update () {
		
	}


	void checkMute(){

		if (PlayerPrefs.GetInt ("mute") == 1) {
		
			camera.GetComponent<AudioSource> ().mute = true;

		
		}

	}

}
