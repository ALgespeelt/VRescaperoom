using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Unlocker))]
public class LockJoint : MonoBehaviour {

    [SerializeField]
    string lockIdentifier;

    Unlocker unlocker;
    GameObject key;

    void Start() {
        unlocker = GetComponent<Unlocker>();
    }

    public void Unlock() {
        unlocker.Unlock();
        print("unLock");
    }

    public void Lock() {
        unlocker.Lock();
        print("Lock");
    }

    void OnTriggerStay(Collider col) {
        KeyJoint joint = col.GetComponentInParent<KeyJoint>();
        if (joint != null) {
            string lockIden = joint.lockIdentifier;
            if (lockIden == lockIdentifier) {
                if (unlocker.getClosed()) {
                    if (unlocker.isLocked()) {
                        joint.insert(Unlock, Quaternion.Euler(- 90f, 0, 0));
                        print("insertUnlock");
                    } else {
                        joint.insert(Lock, Quaternion.Euler(90f, 0, 0));
                        print("insertLock");
                    }
                    key = joint.gameObject;
                }
            }
        }
    }

    void OnTriggerExit(Collider col) {
        KeyJoint joint = col.GetComponentInParent<KeyJoint>();
        if (joint != null) {
            if (joint.gameObject == key) {
                key.GetComponent<KeyJoint>().eject();
                key = null;
                print("Exit");
            }
        }
    }

   
}
