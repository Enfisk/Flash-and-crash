using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour {
    public GameObject pu_target;
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(pu_target.transform.position.x, pu_target.transform.position.y + 0.8f, pu_target.transform.position.z);
	}
}
