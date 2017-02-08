using UnityEngine;
using System.Collections;

public class EmissionSwitcher : MonoBehaviour {

    [SerializeField]
    [ColorUsageAttribute(false, true, 0, 100f, 0.125f, 3f)]
    public Color emmission;
    [SerializeField]
    bool useGI = true;
    [SerializeField]
    bool useLightmanagerEvent;

    Renderer rnd;

    void Start() {
        rnd = GetComponent<Renderer>();
        setEmission(false);
        DynamicGI.UpdateMaterials(rnd);

        if (useLightmanagerEvent) {
            GameObject.FindGameObjectWithTag("Lightmanager").GetComponent<LightManager>()
                .UVEvent.AddListener(setEmission);
        }
    }

    public void setEmission(bool toggle) {
        foreach (Material material in rnd.materials) {
            material.SetColor("_EmissionColor", toggle ? emmission : Color.black);
        }
        if(useGI)
            DynamicGI.UpdateMaterials(rnd);
    }

}
