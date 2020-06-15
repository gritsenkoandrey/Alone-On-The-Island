using UnityEngine.UI;

public sealed class WeaponUiImage : BaseObjectScene
{
    #region Fields

    private Image _image;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();

        _image = GetComponent<Image>();
    }
    #endregion


    #region Methods

    public new void SetActive(bool value)
    {
        _image.gameObject.SetActive(value);
    }

    #endregion
}