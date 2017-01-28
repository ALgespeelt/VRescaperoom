using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(VRTK.VRTK_InteractableObject))]
public class Stickmovement : MonoBehaviour {

    [SerializeField]
    Transform smoothingPos;
    [SerializeField] [Range(0f, 1f)]
    float smoothing;

    bool use = false;

    bool colliding = false;
    Transform playArea;
    Vector3 prevPos;

    VRTK.VRTK_InteractableObject intObj;
    Haptics haptic;
    List<Collider> cols;

    MeshRenderer rnd;

    void Start() {
        prevPos = transform.position;

        smoothingPos = playArea;


        rnd = GetComponentInChildren<MeshRenderer>();
    }

    void OnEnable() {
        playArea = VRTK.VRTK_DeviceFinder.PlayAreaTransform();
        intObj = GetComponent<VRTK.VRTK_InteractableObject>();
        cols = GetComponentsInChildren<Collider>().ToList<Collider>();
        haptic = GetComponent<Haptics>();

        intObj.InteractableObjectUsed += OnUse;
        intObj.InteractableObjectUnused += OnUnuse;
        intObj.InteractableObjectGrabbed += OnGrab;
        intObj.InteractableObjectUngrabbed += OnUngrab;
    }
    
    void OnDisable() {
        intObj.InteractableObjectUsed -= OnUse;
        intObj.InteractableObjectUnused -= OnUnuse;
        intObj.InteractableObjectGrabbed -= OnGrab;
        intObj.InteractableObjectUngrabbed -= OnUngrab;
    }
    
    void Update() {
        prevPos = transform.position;
    }

    void FixedUpdate() {
        if (use && colliding) {
            Vector3 deltaPos = prevPos - transform.position;

            smoothingPos.position = new Vector3(smoothingPos.position.x + deltaPos.x, smoothingPos.position.y, smoothingPos.position.z + deltaPos.z);

            playArea.position = Vector3.Lerp(playArea.position, smoothingPos.position, smoothing);
        }
        rnd.material.color = intObj.IsUsing() & colliding ? Color.green : Color.white;

        prevPos = transform.position;
    }

    void OnUse(object e, VRTK.InteractableObjectEventArgs args) {
        use = true;
    }

    void OnUnuse(object e, VRTK.InteractableObjectEventArgs args) {
        use = false;
    }

    void OnGrab(object e, VRTK.InteractableObjectEventArgs args) {
        foreach(Collider col in cols) {
            col.isTrigger = true;
        }
    }

    void OnUngrab(object e, VRTK.InteractableObjectEventArgs args) {
        foreach (Collider col in cols) {
            col.isTrigger = false;
        }
    }

    void OnTriggerEnter() {
        colliding = true;
        if (haptic && use)
            haptic.TriggerGrabbingHaptics(0.3f);
    }

    void OnTriggerExit() {
        colliding = false;
    }

}
