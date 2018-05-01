using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rigidbody2d;
    public SpringJoint2D joint;
    public Vector2 playerpos;
    public GameObject hook;
	public GameObject ropeSprite;

    public float jumpHeight;
    public float pullSpeed = 1f;

    public float kickBackDistance = 2f;

    public float minimumDistance = 1f;
    public float maximumDistance = 50f;

    public float thrust;

	private AudioSource audioSource;
	public AudioClip collideSound;
	public AudioClip missSound;
	public AudioClip jumpSound;



    void Start () {

		audioSource = GetComponent<AudioSource> ();

        // Safetycheck, makes sure a reference to joint exists
        if (joint == null)
        {
            joint = this.GetComponent<SpringJoint2D>();
        }

        if (rigidbody2d == null)
        {
            rigidbody2d = this.GetComponent<Rigidbody2D>();
        }

        // Resets joint.distance
        joint.distance = 0;

        transform.position = new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"));

    }
	
	void Update () {


        // Throw hook on mouseButtonDown


        if (Input.GetMouseButtonDown(0)) {

            if (!joint.enabled) {

				joint.distance = 250;

                DestroyGrappleHooks();

		

				//ThrowGrapplingHook();
				Instantiate (hook, transform.position, Quaternion.identity);



            }
            else
            {
                DestroyGrappleHooks();
                DisableJoint();

                rigidbody2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            }
        }


        GameObject hooks = GameObject.FindGameObjectWithTag("GrappleHook");

        if (hooks != null)
        {
            if (hooks.GetComponent<Rope>().hooked)
            {
                if (joint.distance < minimumDistance)
                {
                    DestroyGrappleHooks();
                    DisableJoint();
                }
            }
            else
            {
                if (Vector2.Distance(hooks.transform.position, transform.position) > maximumDistance)
                {
                    //hooks.GetComponent<Rope>().ReelInHook();
                    DestroyGrappleHooks();
                    DisableJoint();
					audioSource.PlayOneShot (missSound);
                }
            }
        }

        PullPlayerToHook();


    }

    void FixedUpdate()
    {
        rigidbody2d.AddForce(rigidbody2d.GetRelativePointVelocity(transform.position) * thrust);
        //rigidbody2d.AddRelativeForce(rigidbody2d.GetRelativePointVelocity(transform.position) * thrust);
    }

    public void SetDistance()
	{
        if (Vector2.Distance(joint.connectedAnchor, transform.position) > kickBackDistance)
        {
            joint.distance = Vector2.Distance(joint.connectedAnchor, transform.position);

        } else
        {
            joint.distance = kickBackDistance;
			audioSource.PlayOneShot (jumpSound, 0.5f);
        }

	}


    private void DisableJoint()
    {
        joint.enabled = false;
    }

    public void EnableJoint()
    {
        joint.enabled = true;
    }

    private void PullPlayerToHook()
    {
        // Reduces joint.distance over time
        // Meant to pull the player towards the hook
        joint.distance -= pullSpeed * Time.deltaTime;

    }

    private void ThrowGrapplingHook()
    {
        // Sets hook anchor position to mousePosition
        joint.connectedAnchor = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
    }


	private void DestroyGrappleHooks(){

		GameObject[] oldGrappleHooks;
		oldGrappleHooks = GameObject.FindGameObjectsWithTag ("GrappleHook");

		GameObject oldLine = GameObject.Find ("Line");
		Destroy (oldLine);

		foreach (GameObject oldGrappleHook in oldGrappleHooks) {

			Destroy (oldGrappleHook);

		}

	}


	public void OnCollisionEnter2D(Collision2D other){
	
		audioSource.PlayOneShot (collideSound, 1f);

	}



}
