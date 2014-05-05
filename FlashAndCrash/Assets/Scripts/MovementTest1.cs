using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

[System.Serializable]
[RequireComponent(typeof(Rigidbody))]
public class MovementTest1 : MonoBehaviour
{
    public int deviceNumber;
    public float sensitivity = 1.0f;
    public float maxSpeed = 10.0f;
    private static bool hasIntialized = false;

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
    private static extern int ManyMouse_Init();
    [DllImport("TestApp")]
    private static extern void ManyMouse_Quit();
    [DllImport("TestApp")]
    private static extern int ManyMouse_PollEvent(ref ManyMouseEvent p_event);

    // Use this for initialization
    void Start()
    {
        if (!hasIntialized)
        {
            Debug.Log("ManyMouse Init: " + ManyMouse_Init());
            hasIntialized = true;
        }

        respawnScript = (Respawn) gameObject.GetComponent(typeof(Respawn));
    }

    void OnApplicationQuit()
    {
        ManyMouse_Quit();
    }

    void FixedUpdate()
    {
        if (hasIntialized)
        {
            Debug.Log("if hasInitialized, deviceNumber " + deviceNumber);
            while (ManyMouse_PollEvent(ref mouseEvents) != 0)
            {
                if (mouseEvents.type == ManyMouseEventType.MANYMOUSE_EVENT_RELMOTION && !respawnScript.isRespawning)
                {
                    if (deviceNumber == mouseEvents.device)
                    {
                        if (mouseEvents.item == 0)  //Mouse X Axis
                        {
                            rigidbody.AddForce(mouseEvents.value * sensitivity * Time.deltaTime, 0, 0);
                        }
                        else if (mouseEvents.item == 1)    //Mouse Y Axis
                        {
                            rigidbody.AddForce(0, 0, -mouseEvents.value * sensitivity * Time.deltaTime);
                        }
                    }
                }
            }
        }

        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
    }
}
