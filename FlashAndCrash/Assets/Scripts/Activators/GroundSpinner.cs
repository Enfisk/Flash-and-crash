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
        directions[rotationAxis.X] = Vector3.forward;
        directions[rotationAxis.Y] = Vector3.up;
        directions[rotationAxis.Z] = Vector3.right;
        //directions.Add(rotationAxis.X, Vector3.forward);
        //directions.Add(rotationAxis.Y, Vector3.up);
        //directions.Add(rotationAxis.Z, Vector3.right);

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
            Vector3 facing = go.transform.TransformDirection(directions[Axis]);
            facing[(int)Axis] = 0;

            Debug.Log(string.Format("X: {0} Y: {1} Z: {2}", facing.x, facing.y, facing.z));

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
            temp[(int)Axis] = transform.position[(int)Axis];

            go.transform.position = temp;
            //go.transform.position[(int)rotateAroundAxis] = transform.position[(int)rotateAroundAxis];
            //go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, transform.position.z);
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
