using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public GameObject lastSpawnPoint;
    public Vector3 offset;

    void Start()
    {
        lastSpawnPoint = GameObject.Find("Spawn Point");
    }

    public void Respawn()
    {
        if (lastSpawnPoint == null)
        {
            return;
        }

        transform.position = lastSpawnPoint.transform.position + offset;
        //transform.position = new Vector3(lastSpawnPoint.transform.position.x, lastSpawnPoint.transform.position.y, lastSpawnPoint.transform.position.z);
    }
}
