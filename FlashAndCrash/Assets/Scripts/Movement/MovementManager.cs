using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class MovementManager : MonoBehaviour {
    private List<PlayerMovement> listeners;

    [DllImport("TestApp")]
    private static extern int ManyMouse_Init();
    [DllImport("TestApp")]
    private static extern void ManyMouse_Quit();
    [DllImport("TestApp")]
    private static extern int ManyMouse_PollEvent(ref ManyMouseEvent p_event);

    ManyMouseEvent events = new ManyMouseEvent();

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

    void Awake()
    {
        if (!Globals.ManyMouse_Initialized)
        {
            ManyMouse_Init();
            Globals.ManyMouse_Initialized = true;
        }

        listeners = new List<PlayerMovement>();
    }

    void OnDestroy()
    {
        if (Globals.ManyMouse_Initialized)
        {
            ManyMouse_Quit();
            Globals.ManyMouse_Initialized = false;
        }
    }

    void OnApplicationQuit()
    {
        if (Globals.ManyMouse_Initialized)
        {
            ManyMouse_Quit();
            Globals.ManyMouse_Initialized = false;
        }
    }
    
	// Update is called once per frame
	void Update () {

        while (ManyMouse_PollEvent(ref events) != 0)
        {
            foreach (PlayerMovement script in listeners)
            {
                if (script.deviceNumber == events.device && events.type == ManyMouseEventType.MANYMOUSE_EVENT_RELMOTION)
                {
                    script.OnMouseMovement(events.item, events.value);
                }

                else
                {
                    continue;
                }
            }
        }
	}

    public void AddListener(PlayerMovement p_script)
    {
        if (!listeners.Contains(p_script))
        {
            listeners.Add(p_script);
        }
        else
        {
            Debug.Log("Script alread exists in listeners-list!");
        }
    }
}
