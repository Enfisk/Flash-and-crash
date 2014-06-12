using UnityEngine;
using System.Collections;

public class StartButtonMinimalistic : BaseActivatee {
    public Sprite[] sprites;

    private int activations = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = (SpriteRenderer) GetComponent(typeof(SpriteRenderer));
    }

    public override void Activate()
    {
        activations++;
        spriteRenderer.sprite = activations > sprites.Length - 1 ? sprites[0] : sprites[activations];
    }

    public override void Deactivate(float p_value = 0.0f)
    {
        activations--;
        spriteRenderer.sprite = activations > sprites.Length - 1 ? sprites[0] : sprites[activations];
    }

    private void LoadLevel()     //Fix nice transition later.
    {
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.renderer.material = Resources.Load("Black", typeof(Material)) as Material;

        Application.LoadLevel("Level_1");
    }
	
	// Update is called once per frame
	void Update () {
        if (activations >= 2)
        {
            LoadLevel();
        }

        activations = Mathf.Clamp(activations, 0, 2);
	}
}
