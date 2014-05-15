using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
    public float Degrees = 40.0f;

	// Update is called once per frame
	void Update () {
        transform.Rotate(0 ,Degrees * Time.deltaTime, 0);

	
	}
}
