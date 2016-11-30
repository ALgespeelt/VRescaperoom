using UnityEngine;
using System.Collections;
using System;

public class Unlocker_safe : Unlocker {

    public Rigidbody safeRb;
    public float closesThreshold = 2f;
    [SerializeField]
    bool locked;
    bool closed;

    RigidbodyConstraints initRbC;

    void Start() {
        initRbC = safeRb.constraints;
    }

    public override bool isLocked() {
        return locked;
    }

    public override bool getClosed() {
        return closed;
    }

    public void onDoorChange(float value, float normalized) {
        closed = normalized < closesThreshold;
    }

    public override void Lock() {
        safeRb.constraints = RigidbodyConstraints.FreezeAll;
        locked = true;
    }

    public override void Unlock() {
        safeRb.constraints = initRbC;
        locked = false;
    }
}
