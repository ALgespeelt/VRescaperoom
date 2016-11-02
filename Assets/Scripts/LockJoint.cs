using UnityEngine;
using System.Collections;

public class LockJoint : MonoBehaviour {

    public string lockIdentifier;
    private Unlocker unlocker;
    private Renderer rnd;

    void Start() {
        unlocker = GetComponent<Unlocker>();
        if (unlocker == null) {
            Debug.LogError("unlocker instance not found");
        }
        rnd = GetComponent<Renderer>();
    }

   void Update() {
        if (unlocker.getClosed()) {
            transform.GetChild(0).GetComponent<Renderer>().material.color = Color.yellow;
        } else {
            transform.GetChild(0).GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void OnTriggerEnter(Collider col) {
        KeyJoint joint = col.GetComponent<KeyJoint>();
        if (joint != null) {
            string lockIden = joint.lockIdentifier;
            if (lockIden == lockIdentifier) {
                if (unlocker.getClosed()) {
                    if (unlocker.isLocked()) {
                        unlocker.Unlock();
                        rnd.material.color = Color.green;
                    } else {
                        unlocker.Lock();
                        rnd.material.color = Color.red;
                    }
                }
            }
        }
    }

}
