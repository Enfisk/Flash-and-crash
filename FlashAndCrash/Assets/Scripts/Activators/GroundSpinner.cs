using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundSpinner : MonoBehaviour {
    public BaseActivatee activatee;

    private List<Transform> childList = new List<Transform>();
    private GameObject go;
    private float totalRotation = 0;
    private Vector3 lastPoint;

	// Use this for initialization
	void Start () {
        go = null;

        foreach (Transform child in transform)
        {
            childList.Add(child);
        }
	}

    void OnTriggerEnter(Collider p_other)
    {
        if (go == null && p_other.gameObject.tag.Contains("ball"))
        {
            totalRotation = 0.0f;
            go = p_other.gameObject;
        }
    }

    void OnTriggerExit(Collider p_other)
    {
        if (go != null)
        {
            go = null;
        }
    }

	// Update is called once per frame
	void LateUpdate () {
        if (go != null)
        {
            Vector3 facing = go.transform.TransformDirection(Vector3.forward);
            facing.y = 0;

            float angle = Vector3.Angle(lastPoint, facing);

            foreach (Transform child in childList)
            {
                child.transform.Rotate(Vector3.up, angle);
            }

            if (Vector3.Cross(lastPoint, facing).y < 0)
            {
                angle *= -1;
            }

            activatee.Activate(angle);

            totalRotation += angle;

            lastPoint = facing;
        }
	}
}
