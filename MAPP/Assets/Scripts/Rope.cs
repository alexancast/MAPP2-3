using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

	public Material repMaterial;

    private Vector2 target = new Vector2(0,0);
    public float speed = 1;

    private Rigidbody2D rb;

    private Vector3 sp;

    private GameObject player;

    public bool hooked;
    private float reelInSpeed = 5;

    public float lineWidth = 0.2f;

    private float angle;

    public AudioClip collisionSound;
	private AudioSource audioSource;

    private void Start()
    {


		audioSource = GetComponent<AudioSource> ();

		if (PlayerPrefs.GetInt ("mutefx") == -1)
			audioSource.mute = true;

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

        lr.sortingLayerName = "Line";

		lr.startWidth = lineWidth;
		lr.endWidth = lineWidth;


		lr.material = repMaterial;

        go.transform.position = new Vector3(0,0,-1);
        Vector3 p = player.transform.position;
        Vector3 g = GameObject.FindGameObjectWithTag("GrappleHook").transform.position;
        lr.SetPosition(0, new Vector3(p.x, p.y, p.z - 1));
		lr.SetPosition(1, new Vector3(g.x, g.y, g.z - 1));

        lr.material.mainTextureScale = new Vector2 (distance,1);

        player.GetComponent<PlayerController>().joint.connectedAnchor = new Vector2(transform.position.x, transform.position.y);

        Vector2 v = rb.velocity;
        angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        if (v.x != 0 && v.y != 0)
        {
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.CompareTag("Terrain")){

			audioSource.PlayOneShot (collisionSound, 1f);

            player.GetComponent<PlayerController>().EnableJoint();

            hooked = true;

			rb.velocity = Vector3.zero;
			rb.gravityScale = 0;
		


			player.GetComponent<PlayerController> ().SetDistance ();

        } else if (other.gameObject.CompareTag("AntiHook"))
        {
            audioSource.PlayOneShot(collisionSound, 1f);

            player.GetComponent<PlayerController>().DestroyGrappleHooks();
        }
	}

    public void ReelInHook()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, reelInSpeed);

    }

}
