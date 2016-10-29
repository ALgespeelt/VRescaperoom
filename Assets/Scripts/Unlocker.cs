using UnityEngine;
using System.Collections;

public abstract class Unlocker : MonoBehaviour {

    public bool locked { get; private set; }

    public abstract bool getClosed();

    public abstract void Lock();

    public abstract void Unlock();
}
