using UnityEngine;
using System.Collections;

public class shiftUV : MonoBehaviour {
    public Material material;

    void OnTriggerEnter()
    {
        material.mainTextureOffset = new Vector2(0.5f, 0);
    }
}