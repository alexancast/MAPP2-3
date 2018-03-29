using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public DistanceJoint2D joint;
    public Vector2 v2;

    public Vector2 playerpos;

    public GameObject hook;

    private float hookSpeed = 3;
    private float distance = 0;
    private float pullSpeed = 1;

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
		if (Input.GetMouseButtonDown(0))
        {
            //ThrowGrapplingHook();
            Instantiate(hook, transform.position, Quaternion.identity);
            

        }

        //PullPlayerToHook();

        

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
