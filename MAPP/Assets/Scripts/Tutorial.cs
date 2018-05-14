using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public Image circle;
    public Image arrow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        circle.gameObject.SetActive(true);
        arrow.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        circle.gameObject.SetActive(false);
        arrow.gameObject.SetActive(false);
    }

}
