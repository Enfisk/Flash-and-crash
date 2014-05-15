using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FlickeringLight))]
public class AutoFlickerLight : MonoBehaviour {
    private FlickeringLight flickerScript;

	// Use this for initialization
	void Start () {
        flickerScript = (FlickeringLight)GetComponent(typeof(FlickeringLight));
	}
	
	// Update is called once per frame
	void Update () {
        if (flickerScript.timeSinceLastFlicker >= flickerScript.timeBetweenFlickers)
        {
            if (Random.Range(0, 10) == 3)
            {
                StartCoroutine(flickerScript.FlickerLights());
            }
        }
	}
}
