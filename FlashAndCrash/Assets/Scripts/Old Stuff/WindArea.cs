using UnityEngine;
using System.Collections;

public class WindArea : MonoBehaviour {
    public Vector3 pu_windStrength;

    void OnTriggerEnter(Collider p_other)
    {
        if (p_other.rigidbody)
        {
            p_other.rigidbody.constantForce.force = pu_windStrength;
        }
    }

    void OnTriggerExit(Collider p_other)
    {
        if (p_other.rigidbody)
        {
            p_other.rigidbody.constantForce.force = new Vector3(0, 0, 0);
        }
    }
}
