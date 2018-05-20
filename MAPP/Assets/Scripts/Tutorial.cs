using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public GameObject circle;
    public GameObject innerCircle;

    private void Start()
    {
        circle.SetActive(false);
        innerCircle.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        circle.SetActive(true);
        innerCircle.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        circle.SetActive(false);
        innerCircle.SetActive(false);
    }

}
