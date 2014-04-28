using UnityEngine;
using System.Collections;

public class HoldButton : MonoBehaviour {
    public BaseActivatee[] activatees;
	
    void OnTriggerEnter(Collider p_other)
    {
        if (p_other.tag == "tesla" || p_other.tag == "bucket")
        {
            foreach (BaseActivatee activatee in activatees)
            {
                activatee.Activate();
            }
        }
    }

    void OnTriggerExit(Collider p_other)
    {
        if (p_other.tag == "tesla" || p_other.tag == "bucket")
        {
            foreach (BaseActivatee activatee in activatees)
            {
                activatee.Deactivate();
            }
        }
    }
}
