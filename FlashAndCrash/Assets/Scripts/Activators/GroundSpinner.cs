using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GroundSpinner : MonoBehaviour
{
    public enum rotationAxis
    {
        X = 0,
        Y = 1,
        Z = 2
    }

    public rotationAxis Axis;
    private List<Transform> childList = new List<Transform>();
    private GameObject go;
    private float totalRotation = 0;
    private Vector3 lastPoint;
    private SortedDictionary<rotationAxis, Vector3> directions;

    public BaseActivatee[] activatees;

    // Use this for initialization
    void Start()
    {
        go = null;

        directions = new SortedDictionary<rotationAxis, Vector3>();
        directions.Add(rotationAxis.X, Vector3.right);
        directions.Add(rotationAxis.Y, Vector3.up);
        directions.Add(rotationAxis.Z, Vector3.forward);

        foreach (Transform child in transform)
        {
            if (child.name.Contains("spinners_2")) {
                Debug.Log("Added");
                childList.Add(child);
            }
        }
    }

    void OnTriggerEnter(Collider p_other)
    {
        if (go == null && (p_other.gameObject.tag == "tesla" || p_other.gameObject.tag == "bucket"))
        {
            go = p_other.gameObject;
            lastPoint = go.transform.TransformDirection(directions[Axis]);
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
            Vector3 facing = go.transform.TransformDirection(directions[Axis]);
            facing[(int)Axis] = 0;

            float angle = Vector3.Angle(facing, lastPoint);

            if (Vector3.Cross(lastPoint, facing)[(int)Axis] < 0)
            {
                angle *= -1;
            }

            foreach (Transform child in childList)
            {
                child.transform.Rotate(Vector3.up, angle);
            }

            foreach (BaseActivatee a in activatees)
            {
                a.ActivateWithValue(angle);
            }


            totalRotation += angle;

            lastPoint = facing;

            Vector3 temp = go.transform.position;
            if (Axis == rotationAxis.X)    //I don't like this, but it works.
            {
                temp[2] = transform.position[2];
            }
            else if (Axis == rotationAxis.Z)
            {
                temp[0] = transform.position[0];
            }

            go.transform.position = temp;
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
