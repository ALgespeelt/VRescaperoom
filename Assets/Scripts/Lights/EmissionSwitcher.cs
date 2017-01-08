using UnityEngine;
using System.Collections;

public class EmissionSwitcher : MonoBehaviour {

    [SerializeField]
    [ColorUsageAttribute(false, true, 0, 100f, 0.125f, 3f)]
    Color emmission;
    [SerializeField]
    bool switchTexture = false;
    [SerializeField]
    Texture emissionTexture;

    Color initEmmission;
    Texture initEmissionTexture;

    bool prevState = false;

    Renderer rnd;

    void Start() {
        rnd = GetComponent<Renderer>();

        initEmmission = rnd.material.GetColor("_EmissionColor");
        initEmissionTexture = rnd.material.GetTexture("_EmissionMap");
    }

    public void setEmission(bool toggle) {
        if (toggle) {
            if (!prevState) {
                initEmmission = rnd.material.GetColor("_EmissionColor");
                initEmissionTexture = rnd.material.GetTexture("_EmissionMap");
            }

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
        prevState = toggle;
    }

}
