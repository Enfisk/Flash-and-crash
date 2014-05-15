using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class FlickeringLight : MonoBehaviour {
    public float flickeringTime = 0.5f;     //The total time where the light flickers
    public float timeBetweenFlickers = 0.5f;
    [Range(0, 8)] public float minIntensity = 0.0f;
    [Range(0, 8)] public float maxIntensity = 1.0f;

    private float originalIntensity;
    private bool flickering = false;
    private float timeSinceLastFlicker;

	// Use this for initialization
	void Start () {
        originalIntensity = light.intensity;
	}
	
	// Update is called once per frame
	void Update () {
        if (!flickering)
        {
            if (timeSinceLastFlicker >= timeBetweenFlickers && Random.Range(0, 10) == 3)
            {
                flickering = true;
                StartCoroutine(FlickerLights());
            }

            timeSinceLastFlicker += Time.deltaTime;
        }
	}

    IEnumerator FlickerLights()
    {
        float timePassed = 0.0f;

        while (timePassed < flickeringTime)
        {
            light.intensity = Random.Range(minIntensity, maxIntensity);

            yield return new WaitForEndOfFrame();
            timePassed += Time.deltaTime;
        }

        light.intensity = originalIntensity;
        flickering = false;
        timeSinceLastFlicker = 0.0f;
    }
}
