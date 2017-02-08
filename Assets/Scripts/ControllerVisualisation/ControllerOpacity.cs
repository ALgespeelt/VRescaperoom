using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VRTK.VRTK_InteractTouch), typeof(VRTK.VRTK_ControllerActions))]
public class ControllerOpacity : MonoBehaviour {

    [SerializeField, Range(0f, 1f)]
    float opactity;
    
    bool rbPrevActive = true;

    VRTK.VRTK_InteractTouch touch;
    VRTK.VRTK_ControllerActions controllerActions;
    VRTK.VRTK_ControllerEvents controllerEvents;

    void Start() {
        touch = GetComponent<VRTK.VRTK_InteractTouch>();
        controllerActions = GetComponent<VRTK.VRTK_ControllerActions>();
    }

    void OnEnable() {
        controllerEvents = GetComponent<VRTK.VRTK_ControllerEvents>();

        controllerEvents.ControllerEnabled += ControllerEnable;
    }

    void OnDisable() {
        controllerEvents.ControllerEnabled -= ControllerEnable;
    }

    void ControllerEnable(object sender, VRTK.ControllerInteractionEventArgs args) {
        controllerActions.SetControllerOpacity(touch.IsRigidBodyActive() ? 1f : opactity);
    }

	void Update() {
        if (touch.IsRigidBodyActive() != rbPrevActive) {
            controllerActions.SetControllerOpacity(touch.IsRigidBodyActive() ? 1f : opactity);
        }

        rbPrevActive = touch.IsRigidBodyActive();
    }
}
