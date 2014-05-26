﻿using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
    [HideInInspector] public bool isRespawning { get; set; }      //Use this to stop movement when respawning
    [HideInInspector]
    public GameObject lastSpawnPoint { get; set; }

    public Vector3 offset;
    public float despawnDelay = 0.0f;
    public float respawnDelay = 0.0f;

    void Start()
    {
        isRespawning = false;
        lastSpawnPoint = GameObject.Find("Spawn Point");
    }

    public IEnumerator Spawn()
    {
        if (lastSpawnPoint == null)
        {
            Debug.Log("LastSpawnPoint == null! This shouldn't be happening!!!");
            yield break;
        }

        isRespawning = true;

        //Play Despawn animation here

        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.angularVelocity = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(despawnDelay);

        if (Physics.CheckCapsule(lastSpawnPoint.transform.position + offset, lastSpawnPoint.transform.position + offset, 1))
        {
            transform.position = lastSpawnPoint.transform.position;
        }
        else
        {
            transform.position = lastSpawnPoint.transform.position + offset;
        }

        //Play respawn animation here
        yield return new WaitForSeconds(respawnDelay);

        isRespawning = false;
    }
}
