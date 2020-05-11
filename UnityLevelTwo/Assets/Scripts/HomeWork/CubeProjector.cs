using UnityEngine;


public sealed class CubeProjector : Environment, ISelectObj, ISelectObjImage, ICollision
{
    public string GetMessage()
    {
        return Name;
    }

    public float GetImage()
    {
        return default;
    }
}