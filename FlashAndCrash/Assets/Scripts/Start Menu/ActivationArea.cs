using UnityEngine;
using System.Collections;

public class ActivationArea : MonoBehaviour {
    public BaseActivatee activatee;
    public float waitTime = 2.0f;

    private float timeWaited = 0.0f;
    private bool activated = false;
    
    void OnTriggerStay()
    {
        timeWaited += Time.deltaTime;

        if (timeWaited >= waitTime && !activated)
        {
            activatee.Activate();
            activated = true;
        }
    }

    void OnTriggerExit()
    {
        activatee.Deactivate();
        timeWaited = 0.0f;
        activated = false;
    }
}
