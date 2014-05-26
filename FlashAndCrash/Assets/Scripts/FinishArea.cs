using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinishArea : MonoBehaviour {
    void OnTriggerEnter(Collider p_thing) 
    {
        if (p_thing.tag.Contains("ball"))
        {
            Globals.gameWinner = p_thing.name;
            Globals.gameFinished = true;
        }
    }
}
