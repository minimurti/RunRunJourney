using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;
using LostPolygon.Apple.LocalMultiplayer.Networking;
using System.Collections;
using System;

public class Recieve : MonoBehaviour {
    public AppleLocalMultiplayerNetworkManagerHelper AppleLocalMultiplayerNetworkManagerHelper;
    RotationMessage tiltROOO;
    public static Quaternion vects;
    public static Vector3 accel;
    //end angle math
    int demo;



    public class RotationMessage : MessageBase
    {
        // Some arbitrary message type id number
        //public const short kMessageType = 12344;

        // Position of the tap
        public Vector3 acc;
        public Quaternion att;
    }






    // Use this for initialization
    void Start () {
        LostPolygon.Apple.LocalMultiplayer.AppleLocalMultiplayer.Session.SetLocalPeerName(SystemInfo.deviceName);
        NetworkServer.RegisterHandler(12344, OnServerRecieveGyro);
        AppleLocalMultiplayerNetworkManagerHelper.StartHost();
        //Input.gyro.enabled = true;
        //Debug.Log("yoooo wassup");

    }



    // Update is called once per frame
    //void Update() {
    //}//endUpdate

    private void OnServerRecieveGyro(NetworkMessage netMsg)
    {
        tiltROOO = netMsg.ReadMessage<RotationMessage>();
        vects = tiltROOO.att;
        accel = tiltROOO.acc;
        //tiltROO = tiltROOO.tilty;
        //transform.rotation = tiltROO;
        //transform.Translate(0, 0, -Input.acceleration.z);
        //Debug.Log(tiltROO.ToString());




    }






}
