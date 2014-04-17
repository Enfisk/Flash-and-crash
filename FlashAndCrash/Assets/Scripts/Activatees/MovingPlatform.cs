using UnityEngine;
using System.Collections;

public class MovingPlatform : BaseActivatee
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed;
    public float waitTime;

    private bool hasReachedEnd;
    private float timePassed = 0.0f;

    void Start()
    {
        hasReachedEnd = false;
    }

    override public void ActivateWithValue(float p_value)
    {
        if (p_value >= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, p_value * Time.deltaTime);
        }
        else if (p_value < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, -p_value * Time.deltaTime);
        }
    }

    void Update()
    {
        if (isActivated && (startPoint != null && endPoint != null))
        {
            if (!hasReachedEnd)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
                if (transform.position == endPoint.position)
                {
                    timePassed += Time.deltaTime;
                    if (timePassed >= waitTime)
                    {
                        hasReachedEnd = true;
                        timePassed = 0.0f;
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
                if (transform.position == startPoint.position)
                {
                    timePassed += Time.deltaTime;
                    if (timePassed >= waitTime)
                    {
                        hasReachedEnd = false;
                        timePassed = 0.0f;
                    }
                }
            }
        }
    }
}
