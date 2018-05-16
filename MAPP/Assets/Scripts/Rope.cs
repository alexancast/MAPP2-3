﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

	public Material repMaterial;

    public Vector2 target;
    public float speed = 1;

    private Rigidbody2D rb;

    private Vector3 sp;

    public GameObject player;

    public bool hooked;
    private float reelInSpeed = 5;

	public AudioClip collisionSound;
	private AudioSource audioSource;

    public ParticleSystem particle;

    private void Start()
    {
		audioSource = GetComponent<AudioSource> ();

        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        sp = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = (Input.mousePosition - sp).normalized;
        rb.AddForce(dir * speed);
    }

    private void Update()
    {


		float distance = Vector3.Distance (transform.position, player.transform.position);

		GameObject oldLine;
		oldLine = GameObject.Find ("Line");

		Destroy (oldLine);

		var go = new GameObject ("Line");
		var lr = go.AddComponent<LineRenderer> ();



		lr.startWidth = 0.3f;
		lr.endWidth = 0.3f;


		lr.material = repMaterial;


	
		lr.SetPosition (0, player.transform.position);
		lr.SetPosition (1, GameObject.FindGameObjectWithTag ("GrappleHook").transform.position);


		lr.material.mainTextureScale = new Vector2 (distance,1);

        player.GetComponent<PlayerController>().joint.connectedAnchor = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Terrain")){

			audioSource.PlayOneShot (collisionSound, 1f);

            player.GetComponent<PlayerController>().EnableJoint();

            hooked = true;

			rb.velocity = Vector3.zero;
			rb.gravityScale = 0;
		


			player.GetComponent<PlayerController> ().SetDistance ();

        }
	}

    public void ReelInHook()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, reelInSpeed);

    }

}
