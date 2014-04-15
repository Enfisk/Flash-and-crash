using UnityEngine;
using System.Collections;

public class Lightswitch : MonoBehaviour {
    public BaseActivatee[] activatees;
    private bool activated = false;

    void OnTriggerEnter(Collider p_other)
    {
        activated = !activated;

        if (activated)
        {
            foreach (BaseActivatee activatee in activatees)
            {
                activatee.Activate();
            }
        }
        else
        {
            foreach (BaseActivatee activatee in activatees)
            {
                activatee.Deactivate();
            }
        }
    }
}
