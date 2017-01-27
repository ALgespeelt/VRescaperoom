using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakScript : MonoBehaviour {

    [SerializeField]
    GameObject brokenGameObject;
    [SerializeField]
    float breakThreshold;

	void OnCollisionEnter(Collision col) {
        if(col.relativeVelocity.magnitude >= breakThreshold) {
            GameObject bgo = Instantiate(brokenGameObject, transform.position + col.contacts[0].normal * 0.1f, transform.rotation, transform.parent);
            Rigidbody[] rbs = bgo.GetComponentsInChildren<Rigidbody>();
            Vector3 vel = GetComponent<Rigidbody>().velocity;

            foreach(Rigidbody rb in rbs) {
                rb.velocity = vel;
            }
            
            Destroy(this.gameObject);
        }
    }
}
