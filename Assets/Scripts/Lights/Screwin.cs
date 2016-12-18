using UnityEngine;
using System.Collections;

public class Screwin : MonoBehaviour {

    ConfigurableJoint cj;

	// Use this for initialization
	void Start () {
        cj = GetComponent<ConfigurableJoint>();
	}

    void OnTriggerEnter(Collider col) {
        cj.connectedBody = col.transform.parent.GetComponent<Rigidbody>();
    }
}
