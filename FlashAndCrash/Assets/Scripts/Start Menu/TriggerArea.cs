using UnityEngine;
using System.Collections;

public class TriggerArea : MonoBehaviour {
    public float ActivationDelay;
    [HideInInspector] public bool isTriggered { get; set; }

    private float timeInTrigger;
    private int collidersInTrigger;

    void Start()
    {
        timeInTrigger = 0.0f;
        collidersInTrigger = 0;
    }

    void OnTriggerEnter(Collider p_other)
    {
        if (p_other.tag.Contains("ball"))
        {
            collidersInTrigger += 1;
        }
    }

    void OnTriggerStay(Collider p_other)
    {
        if (p_other.tag.Contains("ball") && collidersInTrigger > 0)
        {
            timeInTrigger += Time.deltaTime;
        }
    }

    void OnTriggerExit(Collider p_other)
    {
        if (p_other.tag.Contains("ball"))
        {
            collidersInTrigger -= 1;

            if (collidersInTrigger == 0)
            {
                timeInTrigger = 0.0f;
            }
        }
    }

    void Update()
    {
        if (timeInTrigger >= ActivationDelay)
        {
            isTriggered = true;
        }
    }
}
