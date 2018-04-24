using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightMeter : MonoBehaviour {

    public Text text;
    public float heightConverter;
    public float heightOffset;

    private GameObject player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	

	void Update () {
        float height = player.transform.position.y;
        height = (int)height * heightConverter - heightOffset;
        text.text = height.ToString() + "m";
	}
}
