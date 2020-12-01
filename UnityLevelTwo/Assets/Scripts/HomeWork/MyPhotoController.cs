using System;
using UnityEngine;
using System.IO;


public sealed class MyPhotoController : BaseController
{
    #region Fields

    private readonly string _folderName = "Screenshot";

    #endregion


    #region Methods

    public void CaptureRenderTexture()
    {
        var cam = ServiceLocatorMonoBehaviour.GetService<Camera>();

        var directory = CheckSaveDirectory();
        var fileName = directory + GetFileName();

        var width = cam.pixelWidth;
        var height = cam.pixelHeight;
        var renderTexture = new RenderTexture(width, height, 24);
        cam.targetTexture = renderTexture;
        var screenShot = new Texture2D(width, height, TextureFormat.RGB24, false);
        cam.Render();
        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        cam.targetTexture = null;
        RenderTexture.active = null;
        UnityEngine.Object.DestroyImmediate(renderTexture);
        var bytes = screenShot.EncodeToPNG();
        File.WriteAllBytes(fileName, bytes);

        Debug.Log($"{_folderName} saved to: {fileName}");
    }
    private string CheckSaveDirectory()
    {
        var path = GetSaveDirectory();
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        return path;
    }

    private string GetSaveDirectory()
    {
        var directory = _folderName;
        //return $"{Directory.GetCurrentDirectory()}/Assets/{directory}/";
        return $"{Directory.GetCurrentDirectory()}/{directory}/";
    }

    private static string GetFileName()
    {
        var screenName = string.Format("{0:ddmmyyyy_hhmmssfff}.png", DateTime.Now);

        return screenName;
    }

    #endregion
}