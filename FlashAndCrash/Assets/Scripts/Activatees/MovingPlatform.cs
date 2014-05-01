using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : BaseActivatee
{
    private List<Transform> m_waypoints = new List<Transform>();
    private Transform m_nextPoint;
    private Vector3 m_movementStep;
	public bool m_AutoActivate;
    public float m_speed;
    public float m_waitTime;

    private float m_timePassed = 0.0f;

    void Start()
    {
		if(m_AutoActivate) 
		{
			isActivated = true;
		}

        for (int i = 0; i < transform.parent.childCount; ++i)
        {

            if (transform.parent.GetChild(i).name.Contains("Waypoint"))
            {
                m_waypoints.Add(transform.parent.GetChild(i));
            }
        }
        m_nextPoint = m_waypoints[0];
    }

    void FixedUpdate()
    {
        if (isActivated && m_waypoints.Count >= 2)
        {
            m_movementStep = Vector3.MoveTowards(rigidbody.position, m_nextPoint.position, m_speed * Time.deltaTime);
                rigidbody.MovePosition(m_movementStep);
                if (rigidbody.position == m_nextPoint.position)
                {
                    m_timePassed += Time.deltaTime;
                    if (m_timePassed >= m_waitTime)
                    {
                        int index = m_waypoints.FindIndex(e => e.transform.position == rigidbody.position);
                        m_nextPoint = index + 1 == m_waypoints.Count ? m_waypoints[0] : m_waypoints[index + 1];
                        m_timePassed = 0.0f;
                    }
                }
        }
    }
}
