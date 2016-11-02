using UnityEngine;
using System.Collections;

public abstract class Unlocker : MonoBehaviour {

    public abstract bool isLocked();

    public abstract bool getClosed();

    public abstract void Lock();

    public abstract void Unlock();
}
