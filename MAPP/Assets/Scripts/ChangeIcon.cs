using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeIcon : MonoBehaviour {

    public Image image;
    public Sprite image1;
    public Sprite image2;
	private GameObject camera;
	private AudioSource[] sounds;

    private void Start()
    {
        //image = GetComponent<Image>();
		camera = GameObject.Find("Main Camera");
		sounds = GameObject.FindObjectsOfType<AudioSource> ();


		if (PlayerPrefs.GetInt ("mute") == 1 && gameObject.name == "MusicMuteButton") {
		
			image.sprite = image1;
		
		} else if(PlayerPrefs.GetInt ("mute") == -1 && gameObject.name == "MusicMuteButton")
			image.sprite = image2;


		if (PlayerPrefs.GetInt ("mutefx") == 1 && gameObject.name == "EffectsMuteButton") {

			image.sprite = image1;

		} else if(PlayerPrefs.GetInt ("mutefx") == -1 && gameObject.name == "EffectsMuteButton")
			image.sprite = image2;




    }

    public void ChangeSprite()
    {
        if (image.sprite != image1)
        {
			//UnMute
            image.sprite = image1;

			if (gameObject.name == "MusicMuteButton") {
				UnMute ();
			} else if (gameObject.name == "EffectsMuteButton") {
			
				UnMuteFX ();
			
			}



        } else
        {
            image.sprite = image2;

			if (gameObject.name == "MusicMuteButton") {
				Mute ();
			} else if (gameObject.name == "EffectsMuteButton") {
			
				MuteFX ();
			
			}
        }
        
    }

	public void UnMute(){

		PlayerPrefs.SetInt("mute", 1);
		Debug.Log("Un Mute");
		camera.GetComponent<AudioSource> ().mute = false;

	
	}


	public void Mute(){

	PlayerPrefs.SetInt ("mute", -1);
	Debug.Log ("Mute");
	camera.GetComponent<AudioSource> ().mute = true;

	}



	public void MuteFX(){

		PlayerPrefs.SetInt ("mutefx", -1);

		foreach(AudioSource audio in sounds){

			if (audio.gameObject.name != "Main Camera") {
				audio.mute = true;
			}

		}
	}

	public void UnMuteFX(){

		PlayerPrefs.SetInt ("mutefx", 1);

		foreach(AudioSource audio in sounds){

			if (audio.gameObject.name != "Main Camera") {
				audio.mute = false;
			}

		}


	}


}
