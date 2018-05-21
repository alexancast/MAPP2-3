using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSound : MonoBehaviour {

	private GameObject camera;

	void Start () {

		camera = GameObject.Find ("Main Camera");

		if (PlayerPrefs.GetInt ("mute") == -1) {
		
			camera.GetComponent<AudioSource> ().mute = true;
		
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
