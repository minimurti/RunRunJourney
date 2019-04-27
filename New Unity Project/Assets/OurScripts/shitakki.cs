using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shitakki : MonoBehaviour
{
    Vector3 accv,vectr,vectrefcross,vectproj;
    float angle, angleref, angleOld,angleDiff;
    Quaternion rot, vectref, vectrefup;
    public bool FlyingLoco,upPressed,Downpressed, Animated;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        rot = Recieve.vects;
        accv = Recieve.accel;

        if (Animated)
        {
            anim = this.GetComponent<Animator>();
            anim.speed = 0f;
        }


        /////////////////////////////BELOW IS THE CODE I WANT YOU TO LOOK AT! 


        if (Input.GetAxis("Vertical") < 0)
        {
            vectref = rot;
            upPressed = true;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            vectrefup = rot;
            angleref = Quaternion.Angle(rot, vectref);
            Downpressed = true;
        }

        angle = Quaternion.Angle(rot, vectref);

        if (angle > angleref)
            angle = angleref; 

        if (Animated && upPressed && Downpressed)
            anim.Play("CINEMA_4D_Main", 0, (angle / angleref));






        //if (MoveForward && upPressed && Downpressed)
        //{
        //    motion = Math.Abs(angleDiff) / SPEEDInverse;
        //    if (motion > moveAmount)
        //        moveAmount = motion;
        //    else
        //        if (moveAmount > 0)
        //        moveAmount -= INETRTIA;
        //    transform.Translate(Vector3.forward * moveAmount);

        //}



        if(FlyingLoco)
            transform.position = accv;
    }
}
