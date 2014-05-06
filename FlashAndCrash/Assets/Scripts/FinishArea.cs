using UnityEngine;
using System.Collections;

public class FinishArea : MonoBehaviour {
    void OnTriggerEnter(Collider p_thing) 
    {
        string name = p_thing.name;
        GameObject FinishText = GameObject.Find(name + " GUI/Win Text");
        if (FinishText)
        {
            FinishText.transform.localPosition = new Vector3(FinishText.transform.localPosition.x, FinishText.transform.localPosition.y, FinishText.transform.localPosition.z + 6);
            collider.enabled = false;
            //gameObject.SetActive(false);
        }

        Globals.gameFinished = true;
    }

    void OnGUI()    //Incredibly much placeholder. Remove later.
    {
        if (Globals.gameFinished) {
            GUI.Label(new Rect(100, 100, 150, 40), "Press Numpad 9 to restart!");
        }
    }
}
