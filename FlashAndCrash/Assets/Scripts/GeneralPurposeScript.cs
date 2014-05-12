//Remove cursor, allow for alt-f4/escape to quit

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class GeneralPurposeScript : MonoBehaviour {
    //private CompletionTimer timer;
    private ScreenshotManager screenshotManager;

    [DllImport("TestApp")]
    private static extern int ManyMouse_Init();
    [DllImport("TestApp")]
    private static extern void ManyMouse_Quit();

	// Use this for initialization
	void Start () {
        if (!Globals.ManyMouse_Initialized)
        {
            ManyMouse_Init();
            Globals.ManyMouse_Initialized = true;
        }

        //timer = (CompletionTimer) gameObject.GetComponent(typeof(CompletionTimer));
        Screen.lockCursor = true;
        screenshotManager = (ScreenshotManager)gameObject.GetComponent(typeof(ScreenshotManager));
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKeyDown(KeyCode.F4)))
        {
            if (Application.isEditor)
            {
                Screen.lockCursor = false;
            }
            else
            {
                Application.Quit();
            }
        }

        if (/*Globals.gameFinished &&*/ Input.GetKeyDown(KeyCode.Keypad9))
        {
            Globals.gameFinished = false;
            Application.LoadLevel(0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            screenshotManager.TakeScreenshot();
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            if (screenshotManager.ScreenshotMode)
            {
                screenshotManager.ExitScreenshotMode();
            }

            else
            {
                screenshotManager.EnterScreenshotMode();
            }
        }

        //if (timer && timer.isActivated)
        //{
        //    Debug.Log(timer.ToString());
        //}
    }
}
