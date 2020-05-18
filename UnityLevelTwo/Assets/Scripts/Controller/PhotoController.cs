using System;
using System.Collections;
using System.IO;
using UnityEngine;

public sealed class PhotoController : BaseController
{
    #region Fields

    private bool _isProcessed;
    private readonly string _path;
    private int _layers = 5;
    private int _resolution = 5;

    #endregion


    #region ClassLyfeCycles

    public PhotoController()
    {
        _path = Application.dataPath;
    }

    #endregion


    #region Methods

    private IEnumerator DoTapExampleAsync()
    {
        _isProcessed = true;
        ServiceLocatorMonoBehaviour.GetService<Camera>().cullingMask = ~(1 << _layers);
        var sw = Screen.width;
        var sh = Screen.height;
        yield return new WaitForEndOfFrame();
        var screen = new Texture2D(sw, sh, TextureFormat.RGB24, true);
        screen.ReadPixels(new Rect(0, 0, sw, sh), 0, 0);
        var bytes = screen.EncodeToPNG();
        var fileName = string.Format("{0:ddMMyyyy_HHmmssfff}.png", DateTime.Now);
        File.WriteAllBytes(Path.Combine(_path, fileName), bytes);
        yield return new WaitForSeconds(2.3f);
        ServiceLocatorMonoBehaviour.GetService<Camera>().cullingMask |= 1 << _layers;
        _isProcessed = false;
    }

    public void FirstMethod()
    {
        var fileName = string.Format("{0:ddMMyyyy_HHmmssfff}.png", DateTime.Now);
        ScreenCapture.CaptureScreenshot(Path.Combine(_path, fileName), _resolution);
    }

    public void SecondMethod()
    {
        DoTapExampleAsync().StartCoroutine();
    }

    #endregion
}