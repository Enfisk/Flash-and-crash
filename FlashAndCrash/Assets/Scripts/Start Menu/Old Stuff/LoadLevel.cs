using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
    public int levelToLoad;

    private TriggerArea triggerScript;

    // Use this for initialization
    void Start()
    {
        triggerScript = (TriggerArea)gameObject.GetComponent(typeof(TriggerArea));
    }
	
	// Update is called once per frame
	void Update () {
        if (triggerScript.isTriggered)
        {
            triggerScript.isTriggered = false;
            Application.LoadLevel(levelToLoad);
        }
	}
}
