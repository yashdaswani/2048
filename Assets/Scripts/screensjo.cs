using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screensjo : MonoBehaviour
{

    private static screensjo instance;
    private Camera mycamera;
    private bool takescreenshotonnextframe;
    private void Awake()
    {
        instance = this;
        mycamera = gameObject.GetComponent<Camera>();
    }
    private void OnPostRender()
    {
        if (takescreenshotonnextframe)
        {
            takescreenshotonnextframe = false;
            RenderTexture renderTexture = mycamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/Renders/Render.png", byteArray);
            Debug.Log("Saved Render interactivo");


            RenderTexture.ReleaseTemporary(renderTexture);
            mycamera.targetTexture = null;
        }
    }

    private void takescreenshot(int width,int height)
    {
        mycamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takescreenshotonnextframe = true;
    }

    public static void takescreenshotstatic(int width,int height)
    {
        instance.takescreenshot(width, height);
    }




    //public Image pictureholder;
    //void Start()
    //{
    //    showpictureholder(false);
    //}

    //private void showpictureholder(bool visible)
    //{
    //    pictureholder.gameObject.SetActive(visible);
    //}

    //public void TakeScreenshot()
    //{
    //    GleyShare.Manager.CaptureScreenshot(ScreenshotCaptured);
    //}

    //private void ScreenshotCaptured(Sprite sprite)
    //{
    //    if (sprite != null)
    //    {
    //        //set captured image on picture holder and enable it
    //        pictureholder.sprite = sprite;
    //        showpictureholder(true);
    //    }
    //}

    ////create the cancel method
    //public void Cancel()
    //{
    //    showpictureholder(false);
    //}

    ////Create share method
    //public void Share()
    //{
    //    GleyShare.Manager.SharePicture();
    //}
}
