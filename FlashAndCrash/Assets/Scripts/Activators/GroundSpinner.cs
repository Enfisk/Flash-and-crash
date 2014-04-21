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
    //private int test = 0;
    private Vector3 lastPoint;
    private SortedDictionary<rotationAxis, Vector3> directions;

    public BaseActivatee[] activatees;

    // Use this for initialization
    void Start()
    {
        go = null;

        directions = new SortedDictionary<rotationAxis, Vector3>();
        //directions[rotationAxis.X] = Vector3.forward;
        //directions[rotationAxis.Y] = Vector3.up;
        //directions[rotationAxis.Z] = Vector3.right;
        directions.Add(rotationAxis.X, Vector3.right);
        directions.Add(rotationAxis.Y, Vector3.up);
        directions.Add(rotationAxis.Z, Vector3.forward);

        foreach (Transform child in transform)
        {
            childList.Add(child);
        }

        //for (int i = 0; i < 2; ++i)
        //{
        //    if (directions[Axis][i] != 0)
        //    {
        //        test = i;
        //    }
        //}
    }

    void OnTriggerEnter(Collider p_other)
    {
        if (go == null && p_other.gameObject.tag.Contains("ball"))
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
            //Debug.Log(string.Format("Direction[Axis {0}] X: {1} Y: {2} Z: {3}", (int)Axis, directions[Axis].x, directions[Axis].y, directions[Axis].z));

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
