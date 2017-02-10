using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Unlocker_drawer : Unlocker {

    [SerializeField]
    bool locked;
    [SerializeField]
    Vector3 closedPosition;
    [SerializeField]
    float closedThershold = 0.01f;
    
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        if (locked) {
            Lock();
        } else {
            Unlock();
        }
    }

    public override bool isLocked() {
        return locked;
    }

    public override bool getClosed() {
        return Vector3.Distance(closedPosition, transform.localPosition) < closedThershold;
    }

    public override void Lock() {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        locked = true;
    }

    public override void Unlock() {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        locked = false;
    }

}
