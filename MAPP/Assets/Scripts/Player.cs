using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject target;
    GameObject currentTarget;

	void Start () {
		
	}
	
	void Update () {

        checkMouseClick();
        launchPlayerAgainstHook();

	}


    void checkMouseClick() {


        if (Input.GetMouseButtonDown(0))
        {

          

                createGrapplingHookTarget();


           
        }
    
    }


    void createGrapplingHookTarget(){

        Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        currentTarget = (GameObject) Instantiate(target, clickPosition, Quaternion.identity);
        currentTarget.GetComponent<Rope>().target = clickPosition;

    }


    void launchPlayerAgainstHook(){

        if (currentTarget != null)
        {


            
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, 0.5f);


           
        
        }
       
    }


}
