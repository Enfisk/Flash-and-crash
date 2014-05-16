﻿using UnityEngine;
using System.Collections;

public class RespawnPoint : MonoBehaviour
{
    [HideInInspector]
    public Light[] lights;
    private Quaternion startRotation;

    void Start()
    {
        lights = GetComponentsInChildren<Light>();

        if (lights.Length > 0)
        {
            startRotation = lights[0].transform.rotation;
        }
    }

    void OnTriggerEnter(Collider p_thing)
    {
        Respawn script = (Respawn)p_thing.GetComponent("Respawn");
        if (script)
        {
            RespawnPoint point = (RespawnPoint)script.lastSpawnPoint.GetComponent(typeof(RespawnPoint));

            foreach (Light light in point.lights)
            {
                light.enabled = false;
            }

            foreach (Light light in lights)
            {
                light.transform.rotation = startRotation;
                light.enabled = true;
            }

            script.lastSpawnPoint = gameObject;
        }
    }
}
