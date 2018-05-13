using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine("CountdownNumber");
    }

    IEnumerator CountdownNumber()
    {
        text.text = "3";
        yield return new WaitForSecondsRealtime(1);
        text.text = "2";
        yield return new WaitForSecondsRealtime(1);
        text.text = "1";

        yield return new WaitForSecondsRealtime(1);
        Destroy(gameObject);
    }
}
