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

    public void Unlock() {
        unlocker.Unlock();
    }

    public void Lock() {
        unlocker.Lock();
    }

    void OnTriggerEnter(Collider col) {
        KeyJoint joint = col.GetComponent<KeyJoint>();
        if (joint != null) {
            gameObject.layer = LayerMask.NameToLayer("keyuninteractable");

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
            gameObject.layer = LayerMask.NameToLayer("keyuninteractable");
            key.GetComponent<KeyJoint>().eject();
        }
    }

   
}
