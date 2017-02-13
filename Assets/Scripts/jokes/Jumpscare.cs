using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour {

    [SerializeField]
    AudioSource audio_base;
    [SerializeField]
    AudioSource audio_scream;
    [SerializeField]
    float closedThreshold;
    [SerializeField]
    float scream_angle;
    [SerializeField]
    float volume;

    bool hasScreamed = false;

    public void OnValueChange(float value, float normalizedValue) {
        if(normalizedValue > closedThreshold) {
            if (normalizedValue < scream_angle) {
                audio_base.volume = normalizedValue / scream_angle * volume;
                if (!audio_base.isPlaying) {
                    audio_base.Play();
                }
            }
            if(normalizedValue >= scream_angle && !hasScreamed) {
                audio_base.Stop();
                audio_scream.Play();
                hasScreamed = true;
            }
        } else {
            audio_base.Stop();
            hasScreamed = false;
        }
    }


}
