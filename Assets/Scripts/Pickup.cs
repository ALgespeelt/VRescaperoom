using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    GameObject item;
    SteamVR_TrackedController trackedController;

    void Start() {
        trackedController = GetComponent<SteamVR_TrackedController>();
        if (trackedController == null) {
            Debug.LogError("No tracked controller script on " + this.name);
        }

        trackedController.TriggerClicked += new ClickedEventHandler(OnTrigerClicked);
        trackedController.TriggerUnclicked += new ClickedEventHandler(OnTrigerReleased);
    }

    void OnTrigerClicked(object sender, ClickedEventArgs e) {
        if (item != null) {
            item.transform.parent = this.transform;
            Rigidbody item_rb = item.GetComponent<Rigidbody>();
            if (item_rb != null) {
                item_rb.isKinematic = true;
            }
        }
    }

    void OnTrigerReleased(object sender, ClickedEventArgs e) {
        if (item != null) {
            item.transform.parent = null;
            Rigidbody item_rb = item.GetComponent<Rigidbody>();
            if (item_rb != null) {
                item_rb.isKinematic = false;
            }
            item = null;
        }
    }

    void OnTriggerEnter(Collider col) {
        Debug.Log(col.name + "enterd the trigger");
        if (col.tag == "interactable") {
            item = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col) {
        Debug.Log(col.name + "exited the trigger");
        if (col.tag == "interactable") {
            //item = null;
        }
    }
	 
}
