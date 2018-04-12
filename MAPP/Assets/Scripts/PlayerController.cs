using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rigidbody2d;
    public SpringJoint2D joint;
    public Vector2 playerpos;
    public GameObject hook;
	
    public float pullSpeed = 1f;
	
    private float minimumDistance = 1f;
    private float maximumDistance = 50f;

    public float thrust;
    private Vector2 velocity;

    void Start () {
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



    }
	
	void Update () {
        // Throw hook on mouseButtonDown
        velocity = rigidbody2d.velocity;


        if (Input.GetMouseButtonDown(0)) {

            if (joint.enabled == false) {

				joint.distance = 250;

                DestroyGrappleHooks();

		

				//ThrowGrapplingHook();
				Instantiate (hook, transform.position, Quaternion.identity);



            }
            else
            {
                DestroyGrappleHooks();
                DisableJoint();
                Debug.Log("disabled");
                //rigidbody2d.velocity = velocity;
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
                    Debug.Log("sluta");
                }
            }
            else
            {
                if (Vector2.Distance(hooks.transform.position, transform.position) > maximumDistance)
                {
                    //hooks.GetComponent<Rope>().ReelInHook();
                    DestroyGrappleHooks();
                    DisableJoint();
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
		joint.distance = Vector2.Distance(joint.connectedAnchor, transform.position);
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

		foreach (GameObject oldGrappleHook in oldGrappleHooks) {

			Destroy (oldGrappleHook);

		}

	}


}
