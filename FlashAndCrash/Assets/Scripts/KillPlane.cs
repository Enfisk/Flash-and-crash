using UnityEngine;
using System.Collections;

public class KillPlane : MonoBehaviour {
    void OnTriggerEnter(Collider p_thing)
    {
        if (p_thing.GetComponent("Respawn"))
        {
            p_thing.SendMessage("Respawn", SendMessageOptions.DontRequireReceiver);
        }
    }
}
