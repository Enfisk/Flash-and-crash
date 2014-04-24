using UnityEngine;
using System.Collections;

public class CameraScriptOld : MonoBehaviour {
    public GameObject pu_objectOne;
    //public GameObject pu_objectTwo;

    private float distanceZ;
	// Use this for initialization
	void Start () {
        //distanceZ = pu_objectOne.transform.position.z - pu_objectTwo.transform.position.z;
	}
	
	// Update is called once per frame
	void LateUpdate () {
       //distanceZ = pu_objectOne.transform.position.z - pu_objectTwo.transform.position.z;
       Vector3 wantedPosition = new Vector3(transform.position.x, transform.position.y, pu_objectOne.transform.position.z - 6);
        //if (distanceZ >= 0) {
            //wantedPosition.Set(transform.position.x, transform.position.y, pu_objectOne.transform.position.z - 6);
       // }
        //else {
        //    wantedPosition.Set(transform.position.x, transform.position.y, pu_objectTwo.transform.position.z - 6);
       // }

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * 6);
	}
}
