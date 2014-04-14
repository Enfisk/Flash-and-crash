using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour
{
    private GameObject go;
    //private float degreesSpun;
    private float totalRotation = 0;

    public int nrOfRotations
    {
        get
        {
            return ((int)totalRotation) / 360;
        }
    }

    private Vector3 lastPoint;

    void Start()
    {
        //degreesSpun = 0.0f;
        go = null;
        lastPoint = transform.TransformDirection(Vector3.forward);
        lastPoint.y = 0;
    }

    void OnTriggerEnter(Collider p_other)
    {
        totalRotation = 0.0f;

        go = p_other.gameObject;
        go.rigidbody.velocity = Vector3.zero;
        go.rigidbody.angularVelocity = Vector3.zero;
        go.transform.rotation = new Quaternion(go.transform.rotation.x, 0.0f, go.transform.rotation.z, go.transform.rotation.w);

        go.transform.position = transform.position;
        //p_other.transform.parent = this.transform;
    }

    void OnTriggerExit(Collider p_other)
    {
        if (go != null)
        {
            go = null;
        }
    }

    void LateUpdate()
    {
        if (go != null)
        {
            transform.rotation = new Quaternion(0.0f, go.transform.rotation.y, 0.0f, go.transform.rotation.w);

            Vector3 facing = transform.TransformDirection(Vector3.forward);
            facing.y = 0;

            float angle = Vector3.Angle(lastPoint, facing);

            if (Vector3.Cross(lastPoint, facing).y < 0)
            {
                angle *= -1;
            }

            totalRotation += angle;

            lastPoint = facing;

            Debug.Log(totalRotation);
            //float oldRotation = transform.rotation.eulerAngles.y;
            ////float rotationDiff = go.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y;
            ////Debug.Log(string.Format("GameObject: {0}, Spinner: {1}", go.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.y));
            //transform.rotation = new Quaternion(0.0f, go.transform.rotation.y, 0.0f, go.transform.rotation.w);

            //float rotationDiff = transform.rotation.eulerAngles.y - oldRotation;
            ////Debug.Log(rotationDiff);

            //degreesSpun += rotationDiff;
            //Debug.Log(degreesSpun);
        }
    }
}
