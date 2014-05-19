using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class WaypointGizmo : MonoBehaviour
{
    private GameObject platform;

    void Awake()
    {
        if (Application.isEditor)
        {
            foreach (Transform child in transform.parent)
            {
                if (child.name.Contains("Platform") || child.name.Contains("Box"))
                {
                    platform = child.gameObject;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (Application.isEditor)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, platform.renderer.bounds.size);
        }
    }
}
