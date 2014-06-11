using UnityEngine;
using System.Collections;

public class ActivationArea : MonoBehaviour {
    public BaseActivatee activatee;
    public float waitTime = 2.0f;
    public Animator anim;

    private float timeWaited = 0.0f;
    private bool activated = false;
    
    void OnTriggerStay()
    {
        timeWaited += Time.deltaTime;

        if (timeWaited >= waitTime && !activated)
        {
            anim.SetBool("Activated", true);
            activatee.Activate();
            activated = true;
        }
    }

    void OnTriggerExit()
    {
        if (activated)
        {
            activatee.Deactivate();
        }
        anim.SetBool("Activated", false);
        timeWaited = 0.0f;
        activated = false;
    }
}
