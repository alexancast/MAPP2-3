using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public DistanceJoint2D joint;
    public Vector2 playerpos;
    public GameObject hook;
	
    public float pullSpeed = 1f;
	
    private float minimumDistance = 1f;
    private float maximumDistance = 50f;
    private float coolDown = 1f;
    private bool coolDownActive;

    void Start () {
        // Safetycheck, makes sure a reference to joint exists
        if (joint == null)
        {
            joint = this.GetComponent<DistanceJoint2D>();
        }

        // Resets joint.distance
        joint.distance = 0;



    }
	
	void Update () {
        // Throw hook on mouseButtonDown
        

        if (coolDownActive == false) {
            

            if (Input.GetMouseButtonDown (0)) {
                EnableJoint();

				joint.distance = 250;

                DestroyGrappleHooks();

		

				//ThrowGrapplingHook();
				Instantiate (hook, transform.position, Quaternion.identity);
            
				coolDownActive = true;


			}
		}


        GameObject hooks = GameObject.FindGameObjectWithTag("GrappleHook");

        if (hooks != null)
        {
            if (hooks.GetComponent<Rope>().hooked)
            {
                Debug.Log("nej");
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


		if (coolDownActive == true) {
			coolDown -= Time.deltaTime;
		}

		if (coolDown <= 0) {

			coolDownActive = false;
			coolDown = 1f;

		
		}

    }





	public void SetDistance()
	{
		joint.distance = Vector2.Distance(joint.connectedAnchor, transform.position);
	}


    private void DisableJoint()
    {
        joint.enabled = false;
    }

    private void EnableJoint()
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
