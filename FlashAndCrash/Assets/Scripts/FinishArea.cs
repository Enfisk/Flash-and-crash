using UnityEngine;
using System.Collections;

public class FinishArea : MonoBehaviour {
    private GameObject winner;
	// Use this for initialization
	void Start () {
        winner = null;
	}

    void OnTriggerEnter(Collider p_thing)
    {
        winner = p_thing.gameObject;
    }

	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (winner != null)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 100, 20), "WINNAR!");
        }
    }
}
