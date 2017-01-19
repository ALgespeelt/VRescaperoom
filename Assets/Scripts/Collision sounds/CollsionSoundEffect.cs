using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionSoundEffect : MonoBehaviour {

    [SerializeField]
    float soundThreshold = 2f;

    new private AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
    }

	void OnCollisionEnter(Collision col) {
        if (col.relativeVelocity.magnitude > soundThreshold) {
            audio.Stop();
            audio.Play();
        }
    }
}
