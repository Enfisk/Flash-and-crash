using UnityEngine;
using System.Collections;

public class StartButtonMinimalistic : BaseActivatee {
    private int activations = 0;

    public override void Activate()
    {
        activations++;
    }

    public override void Deactivate(float p_value = 0.0f)
    {
        activations--;
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
