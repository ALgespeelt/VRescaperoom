using UnityEngine;
using System.Collections;

public class KeyJoint : MonoBehaviour
{
    public string lockIdentifier;
    public bool inserted = false;
    public float threshold;
    public delegate void FinishAction();

    private FinishAction onFinish;
    private Quaternion targetAngle;

    void FixedUpdate() {
        if (inserted) {
            if (Quaternion.Angle(transform.rotation, targetAngle) <= threshold) {
                onFinish();
            } 
        }
    }

    public void insert(FinishAction action, Quaternion targetAngle) {
        onFinish = action;
        this.targetAngle = targetAngle;
        targetAngle = transform.localRotation;
        inserted = true;
    }

    public void eject() {
        inserted = false;
    }

}
