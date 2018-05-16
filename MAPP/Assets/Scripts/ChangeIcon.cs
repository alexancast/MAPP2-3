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
}
