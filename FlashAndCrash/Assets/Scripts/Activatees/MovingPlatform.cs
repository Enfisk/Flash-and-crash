using UnityEngine;
using System.Collections;

public class MovingPlatform : BaseActivatee {
    public Transform startingPoint;
    public Transform endPoint;
    public float speed;
    public float waitTime;

    private bool hasReachedEnd;
    private float timePassed = 0.0f;

	void Start () {
        hasReachedEnd = false;
	}
	
	void Update () {
        if (isActivated && (startingPoint != null && endPoint != null))
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
                transform.position = Vector3.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
                if (transform.position == startingPoint.position)
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
