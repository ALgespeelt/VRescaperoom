using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems : MonoBehaviour {

	[MenuItem("Helpers/EmissionLightMap")]
    static void SetEmissionForLightMap() {
        EmissionSwitcher[] switchers = GameObject.FindObjectsOfType(typeof(EmissionSwitcher)) as EmissionSwitcher[];
        foreach (EmissionSwitcher switcher in switchers) {
            Material[] materials = switcher.GetComponent<MeshRenderer>().sharedMaterials;
            foreach (Material material in materials) {
                material.SetColor("_EmissionColor", switcher.emmission);
            }
        }
    }

    [MenuItem("Helpers/EmissionUndoLightMap")]
    static void UndoEmissionForLightMap() {
        EmissionSwitcher[] switchers = GameObject.FindObjectsOfType<EmissionSwitcher>() as EmissionSwitcher[];
        foreach (EmissionSwitcher switcher in switchers) {
            Material[] materials = switcher.GetComponent<MeshRenderer>().sharedMaterials;
            foreach (Material material in materials) {
                material.SetColor("_EmissionColor", Color.black);
            }
        }
    }

    [MenuItem("Helpers/Toggle Main Light")]
    static void ToggleMainLight() {
        Light light = GameObject.FindGameObjectWithTag("Lightmanager").GetComponent<Light>();
        light.enabled = !light.isActiveAndEnabled;
    }

    [MenuItem("Helpers/Disable destroyImediate")]
    static void DisableDestroyImmediate() {
        VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach[] fixedJointGrabs = GameObject.FindObjectsOfType<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>() 
            as VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach[];

        foreach (VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach fixedJointGrab in fixedJointGrabs) {
            fixedJointGrab.destroyImmediatelyOnThrow = false;
        }
    }
}
