using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSound : MonoBehaviour {

	private GameObject camera;
	private AudioSource[] sounds;

	void Start () {

		camera = GameObject.Find ("Main Camera");
		sounds = GameObject.FindObjectsOfType<AudioSource> ();

		if (PlayerPrefs.GetInt ("mute") == -1) {
		
			camera.GetComponent<AudioSource> ().mute = true;
		
		}

		if (PlayerPrefs.GetInt ("mutefx") == -1) {
		
			foreach (AudioSource audio in sounds) {
				Debug.Log("Muted fx");
				if (audio.name != "Main Camera") {
					audio.mute = true;
			}
			
			}
		
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
