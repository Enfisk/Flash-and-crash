using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

[System.Serializable]
[RequireComponent(typeof(Rigidbody))]
public class MovementTest1 : MonoBehaviour
{
    public int deviceNumber = 0;
    public int rotationMouse = 0;
    public float sensitivity = 1.0f;
    private static bool hasIntialized = false;
    public float speed_x;
    public float speed_y;
    public float speed_z;
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
    [DllImport("TestApp")]
    private static extern string ManyMouse_DriverName();
    [DllImport("TestApp")]
    private static extern string ManyMouse_DeviceName();

    // Use this for initialization
    void Start()
    {
        if (!hasIntialized)
        {
            Debug.Log(ManyMouse_Init());
            hasIntialized = true;

            //Debug.Log("start, deviceNumber " + deviceNumber);
        }
    }

    void OnApplicationQuit()
    {
        ManyMouse_Quit();
    }

    void FixedUpdate()
    {
        speed_x = rigidbody.velocity.x;
        speed_y = rigidbody.velocity.y;
        speed_z = rigidbody.velocity.z;
        if (hasIntialized)
        {
            Debug.Log("if hasInitialized, deviceNumber " + deviceNumber);
            while (ManyMouse_PollEvent(ref mouseEvents) != 0)
            {
                //Debug.Log("ManyMouse_PollEvent, deviceNumber " + deviceNumber);

                if (mouseEvents.type == ManyMouseEventType.MANYMOUSE_EVENT_RELMOTION)
                {
                    if (deviceNumber == mouseEvents.device)
                    {
                        //Debug.Log(deviceNumber);

                        //Debug.Log(string.Format("Device {0}, deviceNumber {1}, value {2}", mouseEvents.device, deviceNumber, mouseEvents.value));
                        if (mouseEvents.item == 0)
                        {
                            rigidbody.AddForce(mouseEvents.value * sensitivity * Time.deltaTime, 0, 0);
                        }
                        else if (mouseEvents.item == 1)
                        {
                            rigidbody.AddForce(0, 0, -mouseEvents.value * sensitivity * Time.deltaTime);
                        }
                    }
                    else if (rotationMouse == mouseEvents.device)
                    {
                        if (mouseEvents.item == 0)
                        {
                            transform.RotateAround(transform.position, Vector3.up, mouseEvents.value * 0.1f/*Time.deltaTime * 90.0f*/);
                        }
                    }
                }
            }
        }

        if (rigidbody.velocity.x > 10)
        {
            rigidbody.velocity.Set(10, rigidbody.velocity.y, rigidbody.velocity.z);
        }
        if (rigidbody.velocity.y > 10)
        {
            rigidbody.velocity.Set(rigidbody.velocity.x, 10, rigidbody.velocity.z);
        }
    }
}
