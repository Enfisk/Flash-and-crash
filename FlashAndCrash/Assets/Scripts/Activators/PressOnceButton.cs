using UnityEngine;
using System.Collections;

public class PressOnceButton : MonoBehaviour {
    public BaseActivatee pu_ObjectToOpen;

    void OnTriggerEnter(Collider p_other)
    {
        pu_ObjectToOpen.Activate();
    }
}