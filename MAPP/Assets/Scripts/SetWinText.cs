using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWinText : MonoBehaviour
{

    public Text timeText;
    public Text ownText;

    void Update()
    {
        ownText.text = timeText.GetComponent<TimeScript>().getTime();

    }


}
