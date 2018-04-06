using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickUpScript : MonoBehaviour {

    public string targetTag;

    private Valve.VR.EVRButtonId triggerbtn = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private SteamVR_TrackedObject tObj;
    private FixedJoint joint;

    [SerializeField]
    private GameObject target;

	void Start () {
        Debug.Log("Pickupscript start");
        tObj = GetComponent<SteamVR_TrackedObject>();
        joint = GetComponent<FixedJoint>();
	}
	
	void FixedUpdate() {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)tObj.index);

        //Debug.Log("Fixed update, Controller is: " + device);
        //Debug.Log(device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger));
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
            if(tObj != null) {
                joint.connectedBody = tObj.GetComponent<Rigidbody>();
                
            }
        }else{
            if(joint.connectedBody != null) {
                target.GetComponent<Rigidbody>().velocity = device.velocity;
                target.GetComponent<Rigidbody>().angularVelocity = device.angularVelocity;
                target.GetComponent<Rigidbody>().maxAngularVelocity = target.GetComponent<Rigidbody>().angularVelocity.magnitude;
                joint.connectedBody = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("COLLISION: " + other.gameObject.name + "with tag: " + other.tag);
        if (other.CompareTag(targetTag)){
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collision exit");
        target = null;
    }
}
