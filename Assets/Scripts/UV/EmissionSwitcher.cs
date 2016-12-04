using UnityEngine;
using System.Collections;

public class EmissionSwitcher : MonoBehaviour {

    public Color emmission;
    public bool switchTexture = false;
    public Texture emissionTexture;

    Color initEmmission;
    Texture initEmissionTexture;

    Renderer rnd;

    void Start() {
        rnd = GetComponent<Renderer>();
    }

    void OnEnable() {
        EmissionToggle.SetEmission += setEmission;
    }

    void OnDisable() {
        EmissionToggle.SetEmission -= setEmission;
    }

    public void setEmission(bool toggle) {
        if (toggle) {
            initEmmission = rnd.material.GetColor("_EmissionColor");
            initEmissionTexture = rnd.material.GetTexture("_EmissionMap");

            rnd.material.SetColor("_EmissionColor", emmission);
            if (switchTexture) {
                rnd.material.SetTexture("_EmissionMap", emissionTexture);
            }
        } else {
            rnd.material.SetColor("_EmissionColor", initEmmission);
            if (switchTexture) {
                rnd.material.SetTexture("_EmissionMap", initEmissionTexture);
            }
        }
    }

}
