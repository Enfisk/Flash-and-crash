using UnityEngine;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
public class WaypointGizmo : MonoBehaviour
{
    private GameObject platform;

    void Awake()
    {
        foreach (Transform child in transform.parent)
        {
            if (child.name.Contains("Platform") || child.name.Contains("Box"))
            {
                Debug.Log("Found it! " + child.name);
                platform = child.gameObject;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, platform.renderer.bounds.size);
    }
}
