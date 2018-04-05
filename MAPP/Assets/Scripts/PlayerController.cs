using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public DistanceJoint2D joint;
    public Vector2 v2;

    public Vector2 playerpos;

    public GameObject hook;
	private float coolDown = 0.5f;
    public float pullSpeed = 1;
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
				joint.distance = 30;

				GameObject[] oldGrappleHooks;
				oldGrappleHooks = GameObject.FindGameObjectsWithTag ("GrappleHook");

				foreach (GameObject oldGrappleHook in oldGrappleHooks) {

					Destroy (oldGrappleHook);

				}

		

				//ThrowGrapplingHook();
				Instantiate (hook, transform.position, Quaternion.identity);
            
				coolDownActive = true;


			}
		}

        PullPlayerToHook();


		if (coolDownActive == true) {
			coolDown -= Time.deltaTime;
		}

		if (coolDown <= 0) {

			coolDownActive = false;
			coolDown = 0.5f;

		
		}

    }





	public void SetDistance()
	{
		joint.distance = Vector2.Distance(joint.connectedAnchor, transform.position);
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
}
