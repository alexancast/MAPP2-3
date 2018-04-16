using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

    public float rollSpeedText;
    public GameObject text;
    public float rollSpeedImage;
    public GameObject image;

    public float backToMenuAtHeight;


    void LateUpdate () {
        text.transform.position += new Vector3(0, rollSpeedText, 0);
        image.transform.position += new Vector3(0, rollSpeedImage, 0);
    }

    private void Update()
    {
        Debug.Log(text.transform.position.y);
        if(text.transform.position.y > backToMenuAtHeight)
        {
            gameObject.GetComponent<Menu>().LoadMenu();
        }
    }
}
