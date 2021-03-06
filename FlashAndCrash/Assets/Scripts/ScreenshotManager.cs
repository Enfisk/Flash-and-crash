﻿using UnityEngine;
using System.Collections;
using System.Linq;
using System.IO;

public class ScreenshotManager : MonoBehaviour {
    [HideInInspector] public bool ScreenshotMode { get; set; }
    public float normalMovespeed;
    public float sprintMultiplier;

    private DirectoryInfo dir;
    private int fileCount;
    private Rect baseViewport;
    private Quaternion baseRotation;
    private Vector3 basePosition;
    private GameObject mainCamera;
    private float originalFixedDT;

    private CameraScript cameraFollowScript;
	
	void Awake () {
        dir = new DirectoryInfo("Screenshots");

        if (!dir.Exists)
        {
            dir = Directory.CreateDirectory("Screenshots");
        }

        fileCount = dir.GetFiles("Screenshot_*.png").Length;

        ScreenshotMode = false;
	}

    void Start()
    {
        mainCamera = Camera.main.gameObject;
        baseViewport = Camera.main.rect;
        baseRotation = mainCamera.transform.rotation;
        basePosition = mainCamera.transform.position;
        cameraFollowScript = (CameraScript)mainCamera.GetComponent(typeof(CameraScript));

        originalFixedDT = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (ScreenshotMode)     //Fuck this shit. Looks so insanely bad.
        {
            #region Input
            if (Input.GetKey(KeyCode.W))
            {
                mainCamera.transform.Translate(transform.forward * normalMovespeed/* * Time.deltaTime*/);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                mainCamera.transform.Translate(-transform.forward * normalMovespeed/* * Time.deltaTime*/);
            }

            if (Input.GetKey(KeyCode.A))
            {
                mainCamera.transform.Translate(-transform.right * normalMovespeed/* * Time.deltaTime*/);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                mainCamera.transform.Translate(transform.right * normalMovespeed/* * Time.deltaTime*/);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                mainCamera.transform.position += transform.up * normalMovespeed/* * Time.deltaTime*/;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                mainCamera.transform.position += -transform.up * normalMovespeed/* * Time.deltaTime*/;
            }

            if (Input.GetKey(KeyCode.Keypad4))
            {
                mainCamera.transform.Rotate(Vector3.up, -10/* * Time.deltaTime*/, Space.World);
            }
            else if (Input.GetKey(KeyCode.Keypad6))
            {
                mainCamera.transform.Rotate(Vector3.up, 10/* * Time.deltaTime*/, Space.World);
            }

            if (Input.GetKey(KeyCode.Keypad8))
            {
                mainCamera.transform.Rotate(-10/* * Time.deltaTime*/, 0, 0);
            }
            else if (Input.GetKey(KeyCode.Keypad2))
            {
                mainCamera.transform.Rotate(10/* * Time.deltaTime*/, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                normalMovespeed *= sprintMultiplier;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
                normalMovespeed /= sprintMultiplier;
            }

            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                Time.timeScale = 0.0f;
                Time.fixedDeltaTime = 0.0f;
            }
            else if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = originalFixedDT;
            }

            #endregion // All input for screenshot mode
        }
    }

    public void TakeScreenshot()
    {
        Application.CaptureScreenshot(string.Format(dir + "\\Screenshot_{0:0000}.png", fileCount + 1));
        fileCount += 1;
    }

    public void EnterScreenshotMode()
    {
        ScreenshotMode = true;
        Camera.main.rect = new Rect(0, 0, 1, 1);
        cameraFollowScript.enabled = false;
    }

    public void ExitScreenshotMode()
    {
        ScreenshotMode = false;
        Camera.main.rect = baseViewport;
        mainCamera.transform.position = basePosition;
        mainCamera.transform.rotation = baseRotation;
        cameraFollowScript.enabled = true;

        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = originalFixedDT;
    }
}
