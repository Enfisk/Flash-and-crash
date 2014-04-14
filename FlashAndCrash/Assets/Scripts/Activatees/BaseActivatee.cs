using UnityEngine;
using System.Collections;

public abstract class BaseActivatee : MonoBehaviour {
    protected bool isActivated { get; set; }

    public virtual void Activate() { isActivated = true; }
    public virtual void Activate(float p_value) { }
    public virtual void Activate(int p_value) { }
    public virtual void Deactivate() { isActivated = false; }
}
