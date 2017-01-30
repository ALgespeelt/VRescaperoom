using UnityEngine;
using System.Collections;

public class EmissionSwitcher : MonoBehaviour {

    [SerializeField]
    [ColorUsageAttribute(false, true, 0, 100f, 0.125f, 3f)]
    Color emmission;
    [SerializeField]
    bool switchTexture = false;
    [SerializeField]
    bool useLightmanagerEvent;

    bool prevState = false;

    Renderer rnd;

    void Start() {
        rnd = GetComponent<Renderer>();
        rnd.material.SetColor("_EmissionColor", Color.black);

        if (useLightmanagerEvent) {
            GameObject.FindGameObjectWithTag("Lightmanager").GetComponent<LightManager>()
                .UVEvent.AddListener(setEmission);
        }
    }

    public void setEmission(bool toggle) {
        if (toggle) {
            rnd.material.SetColor("_EmissionColor", emmission);
        } else {
            rnd.material.SetColor("_EmissionColor", Color.black);
        }
        prevState = toggle;
    }

}
