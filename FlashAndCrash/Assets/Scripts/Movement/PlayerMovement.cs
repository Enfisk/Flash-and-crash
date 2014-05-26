using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {
    public MovementManager manager;
    public int deviceNumber;
    public float maxSpeed = 10;
    public float sensitivity = 10;
    public Inversion invertX = Inversion.No, invertZ = Inversion.No;

    private int xValue = 0;
    private int zValue = 0;

    public enum Inversion
    {
        Yes = -1,
        No = 1
    }

	// Use this for initialization
	void Start () {
        manager.AddListener(this);
	}

    public void OnMouseMovement(uint item, int value)
    {
        if (item == 0)
        {
            xValue += value;
        }
        else if (item == 1)
        {
            zValue += value;
        }
    }

    void FixedUpdate()
    {
        //Debug.Log(string.Format("X-value: {0}, Y-value: {1}, name: {2}", xValue, zValue, gameObject.name));

        if (rigidbody)
            rigidbody.AddForce(xValue * Time.deltaTime * sensitivity * (int)invertX, 0, -zValue * Time.fixedDeltaTime * sensitivity * (int)invertZ, ForceMode.Acceleration);

        xValue = 0;
        zValue = 0;

        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
    }
}
