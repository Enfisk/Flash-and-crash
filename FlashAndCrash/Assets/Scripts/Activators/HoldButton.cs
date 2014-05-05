using UnityEngine;
using System.Collections;

public class HoldButton : MonoBehaviour {
    public BaseActivatee[] activatees;
	
    void OnTriggerEnter(Collider p_other)
    {
        if (p_other.tag == "ball1" || p_other.tag == "ball2")
        {
            foreach (BaseActivatee activatee in activatees)
            {
                activatee.Activate();
            }
        }
    }

    void OnTriggerExit(Collider p_other)
    {
        if (p_other.tag == "ball1" || p_other.tag == "ball2")
        {
            foreach (BaseActivatee activatee in activatees)
            {
                activatee.Deactivate();
            }
        }
    }
}
