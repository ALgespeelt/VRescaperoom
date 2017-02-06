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
    VRTK.VRTK_InteractTouch touch;

    void OnEnable() {
        controllerEvents = GetComponent<VRTK.VRTK_ControllerEvents>();
        grab = GetComponent<VRTK.VRTK_InteractGrab>();
        touch = GetComponent<VRTK.VRTK_InteractTouch>();

        controllerEvents.GripPressed += StartGrabTag;
    }

    void OnDisable() {
        controllerEvents.GripPressed -= StartGrabTag;
    }

    public void StartGrabTag(object sender, VRTK.ControllerInteractionEventArgs args) {
        GameObject grabedObject = GameObject.FindGameObjectWithTag(tagToGrab);
        if (grabedObject) {
            VRTK.VRTK_InteractableObject intObj = grabedObject.GetComponent<VRTK.VRTK_InteractableObject>();
            if (intObj) {
                if (!intObj.IsGrabbed()) {
                    Rigidbody rb = grabedObject.GetComponent<Rigidbody>();
                    if (rb) {
                        rb.MovePosition(transform.position);
                    } else {
                        grabedObject.transform.position = transform.position;
                    }
                    touch.ForceStopTouching();
                    touch.ForceTouch(grabedObject);
                    grab.AttemptGrab();
                }
            }
        }
    }
}
