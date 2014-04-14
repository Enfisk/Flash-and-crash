using UnityEngine;
using System.Collections;

public abstract class BaseActivatee : MonoBehaviour {
    protected bool isActivated { get; set; }

    public virtual void Activate() { isActivated = true; }
    public virtual void Deactivate() { isActivated = false; }
}
