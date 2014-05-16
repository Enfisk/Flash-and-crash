﻿using UnityEngine;
using System.Collections;

public class KillPlane : MonoBehaviour
{
    void OnTriggerEnter(Collider p_thing)
    {
        Respawn script = (Respawn)p_thing.GetComponent(typeof(Respawn));
        if (script)
        {
            StartCoroutine(script.Spawn());
        }
        else
        {
            Destroy(p_thing.gameObject);        //Stops calculations on objects that can't be reached any more
        }
    }
}
