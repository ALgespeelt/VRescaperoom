using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class Radio : MonoBehaviour {

    public AudioMixer radioMixer;
    [Range(80.3f, 108f)] 
    public List<float> frequencys;
    public float widthMulitplier;

    bool state = true;

    public void changeFrequency(float normValue, float value) { 
        float closestFrequency = 0;
        float topVolume = -80f;
        for (int i = 0; i < frequencys.Count; i++) {
            float volume = Mathf.Clamp(-widthMulitplier * Mathf.Pow(normValue-frequencys[i], 4), -80f, 0f);
            if (volume > topVolume)
                closestFrequency = frequencys[i];
            radioMixer.SetFloat("channel " + i.ToString(), volume);
        }
        float noise = Mathf.Clamp(widthMulitplier * Mathf.Pow(normValue - closestFrequency, 4) - 80f, -80f, 0f);
        radioMixer.SetFloat("noise", noise);
        Debug.Log(noise);
    }

    public void onOff() {
        state = !state;
        radioMixer.SetFloat("master", state? -80f: 0f);
    }
}
