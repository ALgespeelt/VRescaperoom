using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VRTK.VRTK_InteractableObject))]
public class Flashlight : MonoBehaviour {

    [SerializeField]
    bool state;
    [SerializeField]
    EmissionSwitcher[] emmisions;
    [SerializeField]
    Light[] lights;

    float[] onIntensities;

    VRTK.VRTK_InteractableObject intObj;

	void OnEnable () {
        intObj = GetComponent<VRTK.VRTK_InteractableObject>();

        intObj.InteractableObjectUsed += OnUse;
    }

    void Start() {
        onIntensities = new float[lights.Length];
        for(int i = 0; i < lights.Length; i++) {
            onIntensities[i] = lights[i].intensity;
            lights[i].intensity = state ? lights[i].intensity : 0f;
        }
        foreach (EmissionSwitcher emmision in emmisions) {
            emmision.setEmission(state);
        }
    }

    void OnDisable() {
        intObj.InteractableObjectUsed -= OnUse;
    }

    void OnUse(object e, VRTK.InteractableObjectEventArgs args) {
        state = !state;
        foreach(EmissionSwitcher emmision in emmisions) {
            emmision.setEmission(state);
        }
        for(int i = 0; i < lights.Length; i++) {
            lights[i].intensity = state ? onIntensities[i] : 0f;
        }
    }
}
