//Remove cursor, allow for alt-f4/escape to quit

using UnityEngine;
using System.Collections;

public class GeneralPurposeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.lockCursor = true;
	}

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKeyDown(KeyCode.F4)))
        {
            if (Application.isEditor)
            {
                Screen.lockCursor = false;
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
