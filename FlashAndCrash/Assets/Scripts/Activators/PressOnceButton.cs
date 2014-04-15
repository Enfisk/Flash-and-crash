using UnityEngine;
using System.Collections;

public class PressOnceButton : MonoBehaviour {
    public BaseActivatee[] activatees;

    void OnTriggerEnter(Collider p_other)
    {
        foreach (BaseActivatee activatee in activatees)
        {
            activatee.Activate();
        }
    }
}