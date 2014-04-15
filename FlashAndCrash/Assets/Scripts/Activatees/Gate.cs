using UnityEngine;
using System.Collections;

public class Gate : BaseActivatee {
    private Vector3 startPoint;
    private Vector3 hidingPoint;
    public float movementSpeed = 10;

	// Use this for initialization
	void Start () {
        startPoint = transform.position;
        hidingPoint = transform.localPosition;
        hidingPoint.x -= renderer.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isActivated)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint, movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, hidingPoint, movementSpeed * Time.deltaTime);
        }
	}
}
