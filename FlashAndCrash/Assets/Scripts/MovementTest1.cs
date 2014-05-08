using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

[System.Serializable]
[RequireComponent(typeof(Rigidbody))]
public class MovementTest1 : MonoBehaviour
{
    public Inversion invertX, invertZ;
    public int deviceNumber;
    public float sensitivity = 1.0f;
    public float maxSpeed = 10.0f;
    private bool isGrounded;

    private Respawn respawnScript;

    ManyMouseEvent mouseEvents = new ManyMouseEvent();

    public enum ManyMouseEventType
    {
        MANYMOUSE_EVENT_ABSMOTION = 0,
        MANYMOUSE_EVENT_RELMOTION,
        MANYMOUSE_EVENT_BUTTON,
        MANYMOUSE_EVENT_SCROLL,
        MANYMOUSE_EVENT_DISCONNECT,
        MANYMOUSE_EVENT_MAX
    };

    public enum Inversion
    {
        Yes = -1,
        No = 1
    }

    public struct ManyMouseEvent
    {
        public ManyMouseEventType type;
        public uint device;
        public uint item;
        public int value;
        public int minval;
        public int maxval;
    };

    [DllImport("TestApp")]
    private static extern int ManyMouse_PollEvent(ref ManyMouseEvent p_event);

    // Use this for initialization
    void Start()
    {
        respawnScript = (Respawn) gameObject.GetComponent(typeof(Respawn));
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 2)) {
            isGrounded = true;
        }

        else {
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        if (Globals.ManyMouse_Initialized)
        {
            Debug.Log("if hasInitialized, deviceNumber " + deviceNumber);
            while (ManyMouse_PollEvent(ref mouseEvents) != 0)
            {
                if (mouseEvents.type == ManyMouseEventType.MANYMOUSE_EVENT_RELMOTION && !respawnScript.isRespawning && isGrounded)
                {
                    if (deviceNumber == mouseEvents.device)
                    {
                        if (mouseEvents.item == 0)  //Mouse X Axis
                        {
                            rigidbody.AddForce((int)invertX * mouseEvents.value * sensitivity * Time.deltaTime, 0, 0);
                        }
                        else if (mouseEvents.item == 1)    //Mouse Y Axis
                        {
                            rigidbody.AddForce(0, 0, (int)invertZ * -mouseEvents.value * sensitivity * Time.deltaTime);
                        }
                    }
                }
            }
        }

        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
    }
}
