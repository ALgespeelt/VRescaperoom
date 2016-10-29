using UnityEngine;
using System.Collections;

public class Unlocker_drawer : Unlocker {

    public new bool locked { get; private set; }
    public float closedThershold = 0.01f;

    private ConfigurableJoint joint;

    void Start() {
        joint = GetComponent<ConfigurableJoint>();
    }

    public override bool getClosed() {
        return transform.position.z < closedThershold;
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
