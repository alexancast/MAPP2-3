using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    public Vector2 target;
    public float speed = 1;

    private Rigidbody2D rb;
    public float amount = 10;

    private Vector3 sp;

    public GameObject player;

    public bool hooked;
    private float reelInSpeed = 5;

	public AudioClip collisionSound;
	private AudioSource audioSource;

    private void Start()
    {
		audioSource = GetComponent<AudioSource> ();

        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        sp = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = (Input.mousePosition - sp).normalized;
        rb.AddForce(dir * amount);
    }

    private void Update()
    {

		GameObject oldLine;
		oldLine = GameObject.Find ("Line");

		Destroy (oldLine);

		var go = new GameObject ("Line");
		var lr = go.AddComponent<LineRenderer> ();


		lr.startWidth = 0.2f;
		lr.endWidth = 0.2f;



		lr.material = new Material(Shader.Find("Standard"));

		lr.startColor = Color.blue;
		lr.endColor = Color.blue;

	
		lr.SetPosition (0, player.transform.position);
		lr.SetPosition (1, GameObject.FindGameObjectWithTag ("GrappleHook").transform.position);


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
