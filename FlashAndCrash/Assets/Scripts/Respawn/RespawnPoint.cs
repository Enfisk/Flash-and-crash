﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnPoint : MonoBehaviour
{
    //public Dictionary<string, Light> lights;
    //private Quaternion startRotation;

    //void Awake()
    //{
    //    lights = new Dictionary<string, Light>();
    //}

    void Start()
    {
        //int playerCount = 1;
        //foreach (Light light in GetComponentsInChildren<Light>())
        //{
        //    lights.Add(string.Format("Player_{0}", playerCount), light);
        //    ++playerCount;
        //}

        //startRotation = lights["Player_1"].transform.rotation;
    }

    void OnTriggerEnter(Collider p_thing)
    {
        Respawn script = (Respawn)p_thing.GetComponent("Respawn");
        if (script)
        {
            //RespawnPoint point = (RespawnPoint)script.lastSpawnPoint.GetComponent(typeof(RespawnPoint));

            //if (lights.Count > 0)
            //{
            //    point.lights[p_thing.name].enabled = false;

            //    lights[p_thing.name].transform.rotation = startRotation;
            //    lights[p_thing.name].enabled = true;
            //}

            script.lastSpawnPoint = gameObject;
        }
    }
}
