using UnityEngine;
using System.Collections;

public class HoldButton : MonoBehaviour {
    public BaseActivatee pu_Object;
   // private Vector3 pr_originalPos;
	// Use this for initialization
	void Start () {
        //pr_originalPos = pu_Object.transform.position;
	}
	
    void OnTriggerEnter(Collider p_other)
    {
        if (p_other.tag == "ball1" || p_other.tag == "ball2")
        {
            pu_Object.Activate();
            //pu_Object.transform.position = new Vector3(pu_Object.transform.position.x, pu_Object.transform.position.y + 10, pu_Object.transform.position.z);
        }
    }

    void OnTriggerExit(Collider p_other)
    {
        if (p_other.tag == "ball1" || p_other.tag == "ball2")
        {
            pu_Object.Deactivate();
            //pu_Object.transform.position = new Vector3(pr_originalPos.x, pr_originalPos.y, pr_originalPos.z);
        }
    }
}
