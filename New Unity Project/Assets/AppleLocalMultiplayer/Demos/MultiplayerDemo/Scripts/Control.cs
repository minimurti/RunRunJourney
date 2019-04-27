using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;
using LostPolygon.Apple.LocalMultiplayer.Networking;

public class Control : MonoBehaviour {
    public AppleLocalMultiplayerNetworkManagerHelper AppleLocalMultiplayerNetworkManagerHelper;
    //public GameObject TapMarkerPrefab;
    Quaternion tiltBRO;
    public GameObject SyncButton;
    Vector3 something;





    public class RotationMessage : MessageBase
    {
        // Some arbitrary message type id number
        //public const short kMessageType = 12344;

        // Position of the tap
        //public Vector3 vectr;
        public Vector3 acc; 
        public Quaternion att;
    }





    // Use this for initialization
    void Start () {
        LostPolygon.Apple.LocalMultiplayer.AppleLocalMultiplayer.Session.SetLocalPeerName(SystemInfo.deviceName);
        //AppleLocalMultiplayerNetworkManagerHelper.StartClient();
        Input.gyro.enabled = true;


    }



    // Update is called once per frame
    void Update() {




        if (NetworkClient.active) { 
            tiltBRO = Input.gyro.attitude;
            something = Input.acceleration;
            NetworkManager.singleton.client.Send(12344, new RotationMessage { acc = something,  att = tiltBRO});
            //NetworkManager.singleton.client.Send(12344, new Quaternion(tiltBRO.x, tiltBRO.y, tiltBRO.z, tiltBRO.w));
            SyncButton.SetActive(false);
        }
        else
            SyncButton.SetActive(true);

       


    }//endUpdate

    public void OnSyncPressed()
    {
        AppleLocalMultiplayerNetworkManagerHelper.StartClient();
    }
}
