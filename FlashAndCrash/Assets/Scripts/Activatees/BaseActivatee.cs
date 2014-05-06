using UnityEngine;
using System.Collections;

public abstract class BaseActivatee : MonoBehaviour {
    [HideInInspector] public bool isActivated { get; set; }

    public virtual void ActivateWithValue(float p_value = 0.0f) { isActivated = true; }
    public virtual void Activate() { isActivated = true; }
    public virtual void Deactivate(float p_value = 0.0f) { isActivated = false; }
}
