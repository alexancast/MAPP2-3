using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeIcon : MonoBehaviour {

    public Image image;
    public Sprite image1;
    public Sprite image2;

    private void Start()
    {
        //image = GetComponent<Image>();
    }

    public void ChangeSprite()
    {
        if (image.sprite != image1)
        {
            image.sprite = image1;
        } else
        {
            image.sprite = image2;
        }
        
    }



	public void Mute(){

		if (PlayerPrefs.GetInt ("mute") == 1) {

			PlayerPrefs.SetInt ("mute", -1);
			Debug.Log ("Mute");

		} else{
			PlayerPrefs.SetInt ("mute", 1);
			Debug.Log("UnMute");
		}


	}



}
