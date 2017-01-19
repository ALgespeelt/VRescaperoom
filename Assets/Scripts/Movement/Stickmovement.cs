using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickmovement : MonoBehaviour {

    bool use = false;
    bool colliding = false;
    Transform playArea;
    Vector3 prevPos;

    void Start() {
        playArea = VRTK.VRTK_DeviceFinder.PlayAreaTransform();

        prevPos = transform.position;
    }
    
    void Update() {
        prevPos = transform.position;
    }

    void FixedUpdate() {
        if (use && colliding) {
            Vector3 deltaPos = prevPos - transform.position;
            playArea.position = new Vector3(playArea.position.x + deltaPos.x, playArea.position.y, playArea.position.z + deltaPos.z);
        }
        prevPos = transform.position;
    }

    public void OnUse() {
        use = true;
    }

    public void OnDisuse() {
        use = false;
    }

    void OnCollisionEnter() {
        colliding = true;
    }

    void OnCollisionExit() {
        colliding = false;
    }

}
