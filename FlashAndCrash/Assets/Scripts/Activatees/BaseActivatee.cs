using UnityEngine;
using System.Collections;

public abstract class BaseActivatee : MonoBehaviour {
    protected bool isActivated { get; set; }

    public virtual void Activate(float p_value = 0.0f) { isActivated = true; }
    public virtual void Deactivate(float p_value = 0.0f) { isActivated = false; }
}
