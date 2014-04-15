using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundSpinner : MonoBehaviour
{
    public BaseActivatee[] activatees;

    private List<Transform> childList = new List<Transform>();
    private GameObject go;
    private float totalRotation = 0;
    private Vector3 lastPoint;

    // Use this for initialization
    void Start()
    {
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
            lastPoint = go.transform.TransformDirection(Vector3.forward);
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
    void Update()
    {
        if (go != null)
        {
            Vector3 facing = go.transform.forward;
            facing.x = 0;

            float angle = Vector3.Angle(facing, lastPoint);

            if (Vector3.Cross(lastPoint, facing).x < 0)
            {
                angle *= -1;
            }

            foreach (Transform child in childList)
            {
                child.transform.Rotate(Vector3.up, angle);
            }

            foreach (BaseActivatee a in activatees)
            {
                a.Activate(angle);
            }


            totalRotation += angle;

            lastPoint = facing;

            go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, transform.position.z);
        }
    }

    void FixedUpdate()
    {
        if (go != null) {
            Vector3 oppositeForce = -go.rigidbody.velocity;
            go.rigidbody.AddForce(oppositeForce * 2);
        }
    }
}
