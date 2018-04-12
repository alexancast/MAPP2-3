using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

    public float rollSpeed;
    public GameObject text;

    public float backToMenuAtHeight;


    void LateUpdate () {
        text.transform.position += new Vector3(0, rollSpeed, 0);
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
