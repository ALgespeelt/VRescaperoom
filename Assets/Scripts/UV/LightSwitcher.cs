using UnityEngine;
using System.Collections;

public class LightSwitcher : MonoBehaviour {

    public Color color;
    public float intensity;

    Color initColor;
    float initIntensity;

    Light l;

    void Start() {
        l = GetComponent<Light>();
    }

    void OnEnable() {
        EmissionToggle.SetEmission += setLight;
    }

    void OnDisable() {
        EmissionToggle.SetEmission -= setLight;
    }

    void setLight(bool state) {
        if (state) {
            initColor = l.color;
            initIntensity = l.intensity;

            l.color = color;
            l.intensity = intensity;
        } else {
            l.color = initColor;
            l.intensity = initIntensity;
        }
    }
}
