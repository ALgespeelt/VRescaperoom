using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LockKnobs : MonoBehaviour {

    public List<VRTK.VRTK_Control> knobs;
    public List<int> correctValues;
    public Unlocker unlocker;
    public float handleThreshold = 1f;
    //public Renderer LockerRnd;

    public void Unlock() {
        unlocker.Unlock();
        //LockerRnd.material.color = Color.green;
    }

    public void Lock() {
        unlocker.Lock();
        //LockerRnd.material.color = Color.red;
    }

    public void OnLeverChange(float abso, float norm) {
        if (unlocker.getClosed()) {
            for (int i = 0; i < knobs.Count; i++) {
                Debug.Log(knobs[i].GetNormalizedValue());
                if (Mathf.RoundToInt(knobs[i].GetNormalizedValue()) != correctValues[i]) {
                    return;
                }
            }
            if(norm < handleThreshold) {
                Unlock();
                Debug.Log("unlocking");
            } else if (norm > 100f - handleThreshold) {
                Lock();
                Debug.Log("locking");
            }
        }
    }
}
