using UnityEngine;
using System.Collections;

public class LockJoint : MonoBehaviour {

    public string lockIdentifier;
    private Unlocker unlocker;

    void Start() {
        unlocker = GetComponent<Unlocker>();
        if (unlocker == null) {
            Debug.LogError("unlocker instance not found");
        }
    }

    void OnTriggerEnter(Collider col) {
        string lockIden = col.GetComponent<KeyJoint>().lockIdentifier;
        if (lockIden != null) {
            if(lockIden == lockIdentifier) {
                if (unlocker.getClosed()) {
                    if (unlocker.locked) {
                        unlocker.Unlock();
                    } else {
                        unlocker.Lock();
                    }
                }
            }
        }
    }

}
