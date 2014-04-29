﻿using UnityEngine;
using System.Collections;

public class RespawnPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider p_thing)
    {
        Respawn script = (Respawn)p_thing.GetComponent("Respawn");
        if (script)
        {
            script.lastSpawnPoint = gameObject;
        }
    }
}
