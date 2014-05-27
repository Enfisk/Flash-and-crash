using UnityEngine;
using System.Collections;

public class shiftUV : MonoBehaviour {
    public Material material;

    private Color baseColor;

    void Awake()
    {
        baseColor = material.color;
    }

    void OnTriggerEnter(Collider P_thing)
    {
        if (P_thing.tag.Contains("ball"))
        {
            material.color = new Color(0f, 1f, 0f);
            material.mainTextureOffset = new Vector2(0.5f, 0);
        }
    }

    void OnApplicationQuit()
    {
        material.color = baseColor;
    }
}