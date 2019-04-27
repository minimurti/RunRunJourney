using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc2 : MonoBehaviour {
    Vector3 test;
    Quaternion test2, test3;
	// Use this for initialization
	void Start () {
        test3 = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		test2 = RotateGear.vectupref;
        transform.rotation = test2;
    }
}
