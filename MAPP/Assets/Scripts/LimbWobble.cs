using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbWobble : MonoBehaviour {

    private GameObject player;
    private Vector3 pos;
    private TargetJoint2D joint;

    public Vector2 offset;
    public Vector2 anchorOffset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //pos = GetComponentInParent<Transform>().position;
        
        joint = GetComponent<TargetJoint2D>();
    }

    void Update () {
        //transform.position = new Vector3(pos.x - offset.x, pos.y - offset.y, pos.z);
        pos = player.transform.position;
        Debug.Log(pos);
        joint.target = new Vector2(pos.x, pos.y) - anchorOffset;
	}
}
