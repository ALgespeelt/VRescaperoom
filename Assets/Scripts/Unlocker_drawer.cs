using UnityEngine;
using System.Collections;
using System;

public class Unlocker_drawer : Unlocker {

    [SerializeField]
    private bool locked;
    public double closedThershold = 0.01;

    private ConfigurableJoint joint;

    void Start() {
        joint = GetComponent<ConfigurableJoint>();
    }

    public override bool isLocked() {
        return locked;
    }

    public override bool getClosed() {
        return Mathf.Abs(transform.localPosition.z) < closedThershold;
    }

    public override void Lock() {
        joint.zMotion = ConfigurableJointMotion.Locked;
        locked = true;
        Debug.logger.Log("locked");
    }

    public override void Unlock() {
        joint.zMotion = ConfigurableJointMotion.Limited;
        locked = false;
        Debug.logger.Log("unlocked");
    }

}
