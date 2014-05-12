using UnityEngine;
using System.Collections;
using System.Linq;
using System.IO;

public class ScreenshotManager : MonoBehaviour {
    private DirectoryInfo dir;
    private int fileCount;
	
	void Awake () {
        dir = new DirectoryInfo("Screenshots");

        if (!dir.Exists)
        {
            dir = Directory.CreateDirectory("Screenshots");
        }

        fileCount = dir.GetFiles("Screenshot_*.png").Length;
	}

    public void TakeScreenshot()
    {
        Application.CaptureScreenshot(string.Format(dir + "\\Screenshot_{0:0000}.png", fileCount + 1));
        fileCount += 1;
    }
}
