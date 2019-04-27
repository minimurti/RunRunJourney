using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateGear : MonoBehaviour {
    Quaternion tiltROO;
    string log;
    bool GearSwitch, ProdPossitive, ProdpossitiveOld;
    float thetad, thetau, thetaMax, AngleNEW, AngleOLD, thetadold, cosinput, accProd;
    static Quaternion vects;
    public static Quaternion vectupref, vectdownref;
    const float Error = 0.015f;
    private Vector3 accv;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        vects = Recieve.vects;
        accv = Recieve.accel;

        transform.rotation = vects;
        transform.position = accv;
           

 
    }





    ////////////////////////////////Button action
    public void OnSyncUp()
    {
        vectupref = vects;
        thetaMax = 0;
    }

    public void OnSyncDown()
    {
        vectdownref = vects;
        thetaMax = 0;
    }



}
