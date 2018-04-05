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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        sp = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = (Input.mousePosition - sp).normalized;
        rb.AddForce(dir * amount);
    }

    private void Update()
    {
        player.GetComponent<PlayerController>().joint.connectedAnchor = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Terrain")){

			player.GetComponent<PlayerController> ().SetDistance ();

        }
	}

}
