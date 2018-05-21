using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeIcon : MonoBehaviour {

    public Image image;
    public Sprite image1;
    public Sprite image2;
	private GameObject camera;

    private void Start()
    {
        //image = GetComponent<Image>();
		camera = GameObject.Find("Main Camera");
		if (PlayerPrefs.GetInt ("mute") == 1 && gameObject.name == "MusicMuteButton") {
		
			image.sprite = image1;
		
		} else if(PlayerPrefs.GetInt ("mute") == -1 && gameObject.name == "MusicMuteButton")
			image.sprite = image2;




    }

    public void ChangeSprite()
    {
        if (image.sprite != image1)
        {
			//UnMute
            image.sprite = image1;
			UnMute ();



        } else
        {
            image.sprite = image2;
			Mute ();
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

}
