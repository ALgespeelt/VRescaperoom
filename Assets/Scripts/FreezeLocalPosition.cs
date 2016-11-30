using UnityEngine;
using System.Collections;

public class FreezeLocalPosition : MonoBehaviour {

    Vector3 initLocalPos;

	// Use this for initialization
	void Start () {
        initLocalPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.localPosition = initLocalPos;
	}
}
