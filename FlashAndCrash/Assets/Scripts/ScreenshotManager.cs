using UnityEngine;
using System.Collections;
using System.Linq;
using System.IO;

public class ScreenshotManager : MonoBehaviour {
    [HideInInspector] public bool ScreenshotMode { get; set; }

    private DirectoryInfo dir;
    private int fileCount;
    private Rect baseViewport;
    private Quaternion baseRotation;
    private Vector3 basePosition;
    private GameObject mainCamera;

    private CameraScript cameraFollowScript;
	
	void Awake () {
        dir = new DirectoryInfo("Screenshots");

        if (!dir.Exists)
        {
            dir = Directory.CreateDirectory("Screenshots");
        }

        fileCount = dir.GetFiles("Screenshot_*.png").Length;

        ScreenshotMode = false;
        mainCamera = Camera.main.gameObject;
        baseViewport = Camera.main.rect;
        baseRotation = mainCamera.transform.rotation;
        basePosition = mainCamera.transform.position;
        cameraFollowScript = (CameraScript)mainCamera.GetComponent(typeof(CameraScript));
	}

    void Update()
    {
        if (ScreenshotMode)     //Fuck this shit. Looks so insanely bad.
        {
            if (Input.GetKey(KeyCode.W))
            {
                mainCamera.transform.Translate(transform.forward * 10.0f * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                mainCamera.transform.Translate(-transform.forward * 10.0f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                mainCamera.transform.Translate(-transform.right * 10.0f * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                mainCamera.transform.Translate(transform.right * 10.0f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                mainCamera.transform.position += transform.up * 10.0f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                mainCamera.transform.position += -transform.up * 10.0f * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Keypad4))
            {
                mainCamera.transform.Rotate(Vector3.up, -60 * Time.deltaTime, Space.World);
            }
            else if (Input.GetKey(KeyCode.Keypad6))
            {
                mainCamera.transform.Rotate(Vector3.up, 60 * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.Keypad8))
            {
                mainCamera.transform.Rotate(-60 * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.Keypad2))
            {
                mainCamera.transform.Rotate(60 * Time.deltaTime, 0, 0);
            }
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
    }
}
