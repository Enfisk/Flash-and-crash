using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour
{
    public Transform nextArea;
    public float movementSpeed;

    private TriggerArea triggerScript;

    // Use this for initialization
    void Start()
    {
        triggerScript = (TriggerArea)gameObject.GetComponent(typeof(TriggerArea));
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerScript.isTriggered)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, nextArea.position, movementSpeed * Time.deltaTime);
        }

        if (Camera.main.transform.position == nextArea.position)
        {
            triggerScript.isTriggered = false;
        }
    }
}
