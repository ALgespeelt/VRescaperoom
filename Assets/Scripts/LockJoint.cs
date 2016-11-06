using UnityEngine;
using System.Collections;

public class LockJoint : MonoBehaviour {

    public string lockIdentifier;
    private Unlocker unlocker;
    private Renderer rnd;
    private GameObject key;

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

    public void Unlock() {
        unlocker.Unlock();
        rnd.material.color = Color.green;
    }

    public void Lock() {
        unlocker.Lock();
        rnd.material.color = Color.red;
    }

    void OnTriggerEnter(Collider col) {
        KeyJoint joint = col.GetComponent<KeyJoint>();
        if (joint != null) {
            string lockIden = joint.lockIdentifier;
            if (lockIden == lockIdentifier) {
                if (unlocker.getClosed()) {
                    if (unlocker.isLocked()) {
                        joint.insert(Unlock, Quaternion.Euler(-90, -90, 180));
                    } else {
                        joint.insert(Lock, Quaternion.Euler(90, 0, 90));
                    }
                    key = col.gameObject;
                }
            }
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.gameObject == key) {
            key.GetComponent<KeyJoint>().eject();
        }
    }

   
}
