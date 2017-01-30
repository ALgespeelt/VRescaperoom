using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BoolEvent : UnityEvent<bool>
{ }

public class LightManager : MonoBehaviour {

    public enum LightState
    {
        Normal,
        UV
    }

    [SerializeField]
    Color UVColor;
    [SerializeField]
    float UVIntensity;
    [SerializeField]
    bool state;
    [SerializeField]
    LightState lightType;
    [SerializeField]
    Screwin socket;
    [SerializeField]
    public BoolEvent StateEvent;
    public BoolEvent UVEvent;

    Color normalColor;
    float normalIntensity;

    private Light l;

	void Start () {
        l = GetComponent<Light>();
        normalColor = l.color;
        normalIntensity = l.intensity;

        if (UVEvent == null) {
            UVEvent = new BoolEvent();
        }

        SetLight();
    }

    void Update() {
        if (socket != null) {
            lightType = socket.GetLightType();
            SetLight();
        }
    }

    public void ToggleLight() {
        state = !state;
        SetLight();
    }

    void SetLight() {
        if (state && socket.GetState()) {
            if (lightType == LightState.Normal) {
                l.intensity = normalIntensity;
                l.color = normalColor;
                UVEvent.Invoke(false);
            } else if (lightType == LightState.UV) {
                l.intensity = UVIntensity;
                l.color = UVColor;
                UVEvent.Invoke(true);
            }
        } else {
            l.intensity = 0f;
            UVEvent.Invoke(false);
        }
        StateEvent.Invoke(state && socket.GetState());
    }
}
