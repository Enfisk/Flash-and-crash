using UnityEngine;
using System.Collections;

public class ActivationArea : MonoBehaviour {
    public BaseActivatee activatee;
    public float waitTime = 2.0f;
    public Animator anim;
    public Transform readyText;

    private float timeWaited = 0.0f;
    private bool activated = false;

    void Start()
    {
        if (!readyText)
        {
            foreach (Transform child in transform)
            {
                if (child.name.Contains("ReadyText"))
                {
                    readyText = child;
                    break;
                }
            }
        }
    }
    
    void OnTriggerStay()
    {
        timeWaited += Time.deltaTime;

        if (timeWaited >= waitTime && !activated)
        {
            anim.SetBool("Activated", true);
            activatee.Activate();
            activated = true;
            readyText.position += new Vector3(0, 2, 0);
        }
    }

    void OnTriggerExit()
    {
        if (activated)
        {
            activatee.Deactivate();
            readyText.position -= new Vector3(0, 2, 0);
        }
        anim.SetBool("Activated", false);
        timeWaited = 0.0f;
        activated = false;
    }
}
