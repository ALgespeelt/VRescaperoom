using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VRTK.VRTK_ControllerEvents), typeof(VRTK.VRTK_InteractGrab))]
public class DistanceGrabTag : MonoBehaviour {

    [SerializeField]
    string tagToGrab;

    bool grabbing;

    VRTK.VRTK_ControllerEvents controllerEvents;
    VRTK.VRTK_InteractGrab grab;

    void OnEnable() {
        controllerEvents = GetComponent<VRTK.VRTK_ControllerEvents>();
        grab = GetComponent<VRTK.VRTK_InteractGrab>();

        controllerEvents.AliasMenuOn += StartGrabTag;
    }

    void OnDisable() {
        controllerEvents.AliasMenuOn -= StartGrabTag;
    }

    public void StartGrabTag(object sender, VRTK.ControllerInteractionEventArgs args) {
        GameObject grabedObject = GameObject.FindGameObjectWithTag(tagToGrab);
        if (grabedObject) {
            VRTK.VRTK_InteractableObject intObj = grabedObject.GetComponent<VRTK.VRTK_InteractableObject>();
            if (intObj) {
                Rigidbody rb = grabedObject.GetComponent<Rigidbody>();
                if (rb) {
                    if (intObj.grabAttachMechanicScript.precisionGrab) {
                        rb.MovePosition(transform.position);
                    } else {
                        rb.MovePosition(transform.position - intObj.grabAttachMechanicScript.rightSnapHandle.localPosition);
                        rb.MoveRotation(intObj.grabAttachMechanicScript.rightSnapHandle.rotation);
                    }
                } else {
                    if (intObj.grabAttachMechanicScript.precisionGrab) {
                        grabedObject.transform.position = transform.position;
                    } else {
                        grabedObject.transform.position = transform.position - intObj.grabAttachMechanicScript.rightSnapHandle.localPosition;
                        grabedObject.transform.rotation = intObj.grabAttachMechanicScript.rightSnapHandle.rotation;
                    }
                }
                grab.AttemptGrab();
            }
        }
    }
}
