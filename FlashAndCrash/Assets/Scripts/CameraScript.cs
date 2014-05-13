using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    public GameObject pu_objectOne;

    public float offsetZ = 2;
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 wantedPosition = new Vector3(pu_objectOne.transform.position.x, transform.position.y, pu_objectOne.transform.position.z - offsetZ);
		transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * offsetZ);
	}
}
