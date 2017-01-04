using UnityEngine;
using System.Collections;

public class Screwin : MonoBehaviour {

    [SerializeField]
    Transform bulbOrigin;
    [SerializeField]
    float maxRotation;

    GameObject bulb;
    Rigidbody bulbRb;
    Quaternion oldRotation;
    float rotation = 0f;

    ConfigurableJoint cj;

	// Use this for initialization
	void Start () {
        cj = GetComponent<ConfigurableJoint>();
	}

    void FixedUpdate() {
        if (bulb != null) {
            if (cj.connectedBody != null) {
                rotation += (Quaternion.Inverse(bulb.transform.rotation)*oldRotation).eulerAngles.y;

                

                oldRotation = bulb.transform.rotation;
            }
        }
    }

    void OnTriggerEnter(Collider col) {
        if (bulb == null) {
            bulb = col.transform.parent.gameObject;
            bulbRb = bulb.GetComponent<Rigidbody>();

            bulb.transform.position = bulbOrigin.position;
            bulb.transform.rotation = bulbOrigin.rotation;

            cj.connectedBody = bulbRb;

            rotation = 0f;
            oldRotation = bulb.transform.rotation;
            Debug.Log(bulb.name + "connected to lamp");
        }
    }
}
