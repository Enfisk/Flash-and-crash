using UnityEngine;
using System.Collections;

public class ColorMatcher : MonoBehaviour
{
    private GameObject go;

    void Start()
    {
        go = null;

        if (!renderer)
        {
            foreach (Transform child in transform)
            {
                if (child.renderer.material.shader.name.Contains("GlowPower"))
                {
                    go = child.gameObject;
                    break;
                }
            }
            light.color = go == null ? Color.white : go.renderer.material.GetColor("_Color");
        }
    }

    void Update()
    {
        if (go != null && rigidbody)
        {
            float velocity = rigidbody.velocity.x > rigidbody.velocity.z ? Mathf.Clamp(Mathf.Abs(rigidbody.velocity.x), 0, 3) : Mathf.Clamp(Mathf.Abs(rigidbody.velocity.z), 0, 3);
            go.renderer.material.SetFloat("_GlowPower", velocity);
        }
    }
}
