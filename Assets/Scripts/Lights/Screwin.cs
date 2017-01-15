using UnityEngine;
using System.Collections;

public class Screwin : MonoBehaviour {

    [SerializeField]
    Transform bulbOrigin;
    [SerializeField]
    float maxRotation;
    [SerializeField]
    float positionLimit;
    [SerializeField]
    LightManager lightM;

    GameObject bulb;
    Rigidbody bulbRb;
    Bulb bulbBulb;
    Quaternion oldRotation;
    Quaternion initialRotation;
    float rotation = 0f;
    
    ConfigurableJoint cj;
    
	void Start () {
        cj = GetComponent<ConfigurableJoint>();
	}

    void FixedUpdate() {
        if (bulb != null) {
            if (cj.connectedBody != null) {
                float angle =  oldRotation.eulerAngles.y - bulb.transform.rotation.eulerAngles.y;
                angle = Mathf.Round(angle * 1000f) / 1000f;
                if (angle > 0 && angle <= 180) {
                    rotation += Quaternion.Angle(oldRotation, bulb.transform.rotation);
                } else {
                    rotation -= Quaternion.Angle(oldRotation, bulb.transform.rotation);
                }

                if (rotation < 0 ) {
                    EjectBulb();
                }

                if(rotation> maxRotation) {
                    bulb.transform.rotation = oldRotation;
                    rotation = maxRotation;
                }

                cj.targetPosition = Vector3.right * (Mathf.InverseLerp(0, maxRotation, rotation) * positionLimit * 2 - positionLimit);

                oldRotation = bulb.transform.rotation;
            }
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "bulb") {
            if (bulb == null) {
                bulb = col.transform.parent.gameObject;
                bulbRb = bulb.GetComponent<Rigidbody>();
                bulbBulb = bulb.GetComponent<Bulb>();

                bulb.transform.position = bulbOrigin.position;
                bulb.transform.rotation = bulbOrigin.rotation;

                cj.connectedBody = bulbRb;

                bulbRb.useGravity = false;

                lightM.StateEvent.AddListener(bulb.GetComponentInChildren<EmissionSwitcher>().setEmission);

                rotation = 0f;
                oldRotation = bulb.transform.rotation;
                initialRotation = oldRotation;
            }
        }
    }

    void OnTiggerLeave(Collider col) {
        if (col.tag == "bulb") {
            EjectBulb();
        }
    }

    void EjectBulb() {
        bulbRb.useGravity = true;

        lightM.StateEvent.RemoveListener(bulb.GetComponentInChildren<EmissionSwitcher>().setEmission);

        rotation = 0;

        bulb = null;
        bulbRb = null;
        cj.connectedBody = null;
    }

    public LightManager.LightState GetLightType() {
        if (bulbBulb == null) {
            return LightManager.LightState.Normal;
        }
        return bulbBulb.state;
    }

    public bool GetState() {
        //return rotation >= maxRotation;
        return true;
    }
}
