using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    FixedJoint joint;
    
	void Start () {
        joint = GetComponent<FixedJoint>();
	}
	
	 
}
