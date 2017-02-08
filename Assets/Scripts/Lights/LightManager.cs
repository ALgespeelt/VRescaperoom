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
    bool state;
    [SerializeField]
    LightState lightType;
    [SerializeField]
    Screwin socket;
    [HideInInspector]
    public BoolEvent StateEvent;
    public BoolEvent UVEvent;

    Color normalColor;
    float normalIntensity;
    LightState prevLightType;
    bool prevScrewinState;

    private Light l;

	void Start () {
        l = GetComponent<Light>();
        normalColor = l.color;
        normalIntensity = l.intensity;

        if (UVEvent == null) {
            UVEvent = new BoolEvent();
        }

        if(StateEvent == null) {
            StateEvent = new BoolEvent();
        }

        prevLightType = socket.GetLightType();
        prevScrewinState = socket.GetState();

        SetLight();
    }

    void Update() {
        if (socket != null) {
            if (prevLightType != socket.GetLightType() || prevScrewinState != socket.GetState()) {
                lightType = socket.GetLightType();
                SetLight();
            }
            prevLightType = socket.GetLightType();
            prevScrewinState = socket.GetState();
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
                StateEvent.Invoke(true);
            } else if (lightType == LightState.UV) {
                l.intensity = 0f;
                UVEvent.Invoke(true);
            }
        } else {
            l.intensity = 0f;
            UVEvent.Invoke(false);
            StateEvent.Invoke(false);
        }
    }
}
