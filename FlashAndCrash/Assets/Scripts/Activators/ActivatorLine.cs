using UnityEngine;
using System.Collections;

public class ActivatorLine : BaseActivatee {
    public Material copyMat;
    public Vector2 offset;

    private Material mat;

	// Use this for initialization
	void Start () {
        mat = new Material(copyMat);
        renderer.material = mat;
	}

    public override void Activate()
    {
        mat.mainTextureOffset = new Vector2(mat.mainTextureOffset.x + offset.x, mat.mainTextureOffset.y + offset.y);
    }
}
