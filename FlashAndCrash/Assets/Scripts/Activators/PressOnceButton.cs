using UnityEngine;
using System.Collections;

public class PressOnceButton : MonoBehaviour {
    public BaseActivatee[] activatees;

    private MultisoundEmitter soundScript;
    private bool isActivated = false;

    void Start()
    {
        soundScript = (MultisoundEmitter) gameObject.GetComponent(typeof(MultisoundEmitter));
    }

    void OnTriggerEnter(Collider p_other)
    {
        if (!isActivated)
        {
            if (p_other.tag.Contains("ball"))
            {
                foreach (BaseActivatee activatee in activatees)
                {
                    activatee.Activate();
                }

                soundScript.PlaySound("button_press");
                isActivated = true;
            }
        }
    }
}