using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public GameObject lastSpawnPoint;
    public Vector3 offset;

    void Start()
    {
        lastSpawnPoint = GameObject.Find("Spawn Point");
    }

    public void Spawn()
    {
        if (lastSpawnPoint == null)
        {
            return;
        }

        transform.position = lastSpawnPoint.transform.position + offset;
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.angularVelocity = new Vector3(0, 0, 0);
    }
}
