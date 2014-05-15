using UnityEngine;
using System.Collections;

public class FinishArea : MonoBehaviour {
    void OnTriggerEnter(Collider p_thing) 
    {
        if (p_thing.tag.Contains("ball"))
        {
            string winnerName = p_thing.name == "Player_1" ? "Player_1" : "Player_2";
            string loserName = p_thing.name == "Player_1" ? "Player_2" : "Player_1";
            GameObject winText = GameObject.Find(winnerName + " GUI/Win Text");
            GameObject loseText = GameObject.Find(loserName + " GUI/Lose Text");
            if (winText)
            {
                winText.transform.localPosition = new Vector3(winText.transform.localPosition.x, winText.transform.localPosition.y, winText.transform.localPosition.z + 8);
                loseText.transform.localPosition = new Vector3(loseText.transform.localPosition.x, loseText.transform.localPosition.y, loseText.transform.localPosition.z + 8);
                collider.enabled = false;
            }

            Globals.gameFinished = true;
        }
    }
}
