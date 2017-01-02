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
            if (bulb.transform.position == bulbOrigin.position && bulb.transform.rotation == bulbOrigin.rotation) {
                cj.connectedBody = bulbRb;
            }

            if (cj.connectedBody != null) {
                rotation += Quaternion.Angle(bulb.transform.rotation, oldRotation);
                if (Quaternion.Angle(bulb.transform.rotation, oldRotation) > 0) {
                    Debug.Log(Quaternion.Angle(bulb.transform.rotation, oldRotation));
                }

                Vector3 newPos = Vector3.up * (bulb.transform.position.y + rotation / 10);
                bulbRb.MovePosition(newPos);

                oldRotation = bulb.transform.rotation;
            }
        }
    }

    void OnTriggerEnter(Collider col) {
        if (bulb == null) {
            bulb = col.transform.parent.gameObject;
            bulbRb = bulb.GetComponent<Rigidbody>();

            bulbRb.MovePosition(bulbOrigin.position);
            bulbRb.MoveRotation(bulbOrigin.rotation);

            bulbRb.isKinematic = true;

            rotation = 0f;
            oldRotation = bulb.transform.rotation;
            Debug.Log(bulb.name + "connected to lamp");
        }
    }
}
