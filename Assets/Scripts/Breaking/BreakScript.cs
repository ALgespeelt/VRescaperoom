using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakScript : MonoBehaviour {
    [System.Serializable]
    struct BreakObject
    {
        public GameObject brokenObject;
        public Transform objectTransform;
    }

    [SerializeField]
    BreakObject[] breakObjects;
    [SerializeField]
    float breakThreshold;

	void OnCollisionEnter(Collision col) {
        if(col.relativeVelocity.magnitude >= breakThreshold) {
            for(int i = 0; i < breakObjects.Length; i++) {
                GameObject bgo = Instantiate(breakObjects[i].brokenObject, breakObjects[i].objectTransform.position + col.contacts[0].normal * 0.1f, 
                    breakObjects[i].objectTransform.rotation, transform.parent);

                Rigidbody[] rbs = bgo.GetComponentsInChildren<Rigidbody>();
                Vector3 vel = GetComponent<Rigidbody>().velocity;
                Vector3 angVel = GetComponent<Rigidbody>().angularVelocity;

                foreach (Rigidbody rb in rbs) {
                    rb.velocity = vel;
                    rb.angularVelocity = angVel;
                }
            }

            Destroy(this.gameObject);
        }
    }
}
