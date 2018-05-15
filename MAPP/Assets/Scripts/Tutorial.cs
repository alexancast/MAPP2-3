using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public GameObject circle;
    public GameObject arrow;

    private void OnTriggerStay2D(Collider2D collision)
    {
        circle.SetActive(true);
        arrow.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        circle.SetActive(false);
        arrow.SetActive(false);
    }

}
