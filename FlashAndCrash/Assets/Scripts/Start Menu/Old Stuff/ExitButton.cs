using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {
    private TriggerArea triggerScript;

	// Use this for initialization
	void Start () {
        triggerScript = (TriggerArea) gameObject.GetComponent(typeof(TriggerArea));
	}
	
	// Update is called once per frame
	void Update () {
        if (triggerScript.isTriggered)
        {
            triggerScript.isTriggered = false;
            Application.Quit();
        }
	}
}
