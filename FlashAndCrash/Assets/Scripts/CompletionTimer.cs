using UnityEngine;
using System.Collections;

public class CompletionTimer : BaseActivatee {
    public float timePassed     //Returns the time passed in seconds
    {
        get;

        set;
    }

	// Use this for initialization
	void Start () {
        timePassed = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (isActivated)
        {
            timePassed += Time.deltaTime;
        }
	}

    public override void Activate()
    {
        base.Activate();
    }

    public override void Deactivate(float p_value = 0.0f)
    {
        base.Deactivate(p_value);
    }

    public override string ToString()
    {
        return string.Format("{0:00}:{1:00}.{2:000}", (int)timePassed / 60, (int)timePassed % 60, (int)(timePassed * 100) % 100);
    }
}
