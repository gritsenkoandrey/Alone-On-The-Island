public sealed class Wall : BaseObjectScene, ISelectObj, ISelectObjImage
{
    #region Methods

    public string GetMessage()
    {
        return Name;
    }

    public float GetImage()
    {
        return default;
    }

    #endregion
}