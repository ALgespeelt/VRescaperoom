using UnityEngine;
using System.Collections;

public class KeyJoint : MonoBehaviour
{

    [HideInInspector]
    public bool inserted = false;
    public delegate void FinishAction();

    [SerializeField]
    public string lockIdentifier;
    [SerializeField]
    float threshold;

    FinishAction onFinish;
    Quaternion targetAngle;
    Collider[] cols;

    void Start() {
        cols = GetComponentsInChildren<Collider>();
    }

    void FixedUpdate() {
        if (inserted) {
            print(Quaternion.Angle(transform.rotation, targetAngle));
            if (Quaternion.Angle(transform.rotation, targetAngle) <= threshold) {
                onFinish();
            } 
        }
    }

    public void insert(FinishAction action, Quaternion angle) {
        onFinish = action;
        targetAngle = angle;
        inserted = true;
        foreach (Collider col in cols) {
            col.isTrigger = true;
        }
    }

    public void eject() {
        inserted = false;
        foreach (Collider col in cols) {
            col.isTrigger = false;
        }
    }

}
