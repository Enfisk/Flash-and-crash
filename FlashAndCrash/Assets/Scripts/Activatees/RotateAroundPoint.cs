using UnityEngine;
using System.Collections;

public class RotateAroundPoint : BaseActivatee {
    private Transform point;

    public float speed = 1;
    public float minAngle = 0;
    public float maxAngle = 90;

	// Use this for initialization
	void Start () {
        foreach (Transform child in transform.root)
        {
            if (child.name == "rotatePoint")
            {
                point = child;
                break;          //We only want the first transform found
            }
        }
	}

    override public void ActivateWithValue(float p_value)
    {
        if (Vector3.Angle(Vector3.up, transform.up) < maxAngle) {
            transform.RotateAround(point.position, transform.right, p_value * speed * Time.deltaTime);
        }
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, ClampAngle(transform.eulerAngles.z, minAngle, maxAngle));
    }

	// Update is called once per frame
	void Update () {
        if (isActivated)
        {
            transform.RotateAround(point.position, transform.right, speed * Time.deltaTime);
        }
	}

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }

        return Mathf.Clamp(angle, min, max);
    }
}
