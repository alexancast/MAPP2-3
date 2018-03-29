using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    public Vector2 target;
    public float speed = 1;

	private void Update()
	{
        setHookPosition();


	}


    void setHookPosition(){

        transform.position = Vector2.MoveTowards (transform.position, target, speed);
    }



	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player")){


        }
	}

}
