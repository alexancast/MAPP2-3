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

        if (currentTarget != null)
        {
            if (currentTarget.transform.position != transform.position)
            {
                launchPlayerAgainstHook();
            }
        }
	}


    void checkMouseClick() {


        if (Input.GetMouseButtonDown(0))
        {

            Destroy(currentTarget);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

                if (hit)
                {



                    Debug.Log(hit.collider.gameObject.name);
                    createGrapplingHookTarget();


                }
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


	private void OnCollisionEnter(Collision other)
	{



            if(other.collider.CompareTag("Terrain")){

                currentTarget = null;

            }

        }

}



