using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EmissionToggle : MonoBehaviour {

    public delegate void EmissionAction(bool state);
    public static event EmissionAction SetEmission;

    bool state;

    public void toggleEmission() {
        if (SetEmission != null) {
            state = !state;
            SetEmission(state);
        }
    }
}
