using UnityEngine;
using System.Collections;

public class TeslaGenerator : MonoBehaviour {
    private GameObject go;
    public GameObject connectedObject
    {
        get
        {
            return go != null ? go : null;
        }
    }

	// Use this for initialization
	void Start () {
        go = null;
	}

    void OnTriggerEnter(Collider p_other)
    {
        if (p_other.gameObject.tag == "tesla")
        {
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
}
