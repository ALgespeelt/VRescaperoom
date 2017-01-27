using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VRTK.VRTK_InteractableObject))]
public class Haptics : MonoBehaviour {

    VRTK.VRTK_InteractableObject intObj;

    void Start() {
        intObj = GetComponent<VRTK.VRTK_InteractableObject>();
    }

    public void TriggerGrabbingHaptics(float strength) {
        if(strength < 0f || strength > 1f) {
            Debug.LogError("Strength is invalid");
            return;
        }
        intObj.GetGrabbingObject().GetComponent<VRTK.VRTK_ControllerActions>().TriggerHapticPulse(strength);
    }

    public void TriggerTouchingHaptics(float strength) {
        if (strength < 0f || strength > 1f) {
            Debug.LogError("Strength is invalid");
            return;
        }
        foreach(GameObject obj in intObj.GetTouchingObjects()) {
            obj.GetComponent<VRTK.VRTK_ControllerActions>().TriggerHapticPulse(strength);
        }
    }
}
