using UnityEngine;
using System.Collections;

public class lightswitch : MonoBehaviour {

    public Light l;
    public bool state;
    private float onIntensity;

    void Start() {
        onIntensity = l.intensity;
        l.intensity = state ? 1f : 0f * onIntensity;
    }

    public void toggleLight() {
        state = !state;
        l.intensity = state ? 1f : 0f * onIntensity;
    }
}
