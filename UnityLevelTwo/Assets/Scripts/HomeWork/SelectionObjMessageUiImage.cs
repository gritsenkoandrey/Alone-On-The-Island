using UnityEngine;
using UnityEngine.UI;


public sealed class SelectionObjMessageUiImage : BaseObjectScene
{
    #region Fields

    private Image _image;

    #endregion


    #region Properties

    public float Fill
    {
        set { _image.fillAmount = value; }
    }

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();

        _image = GetComponent<Image>();
    }

    #endregion


    #region Methods

    public void SetColor(Color value)
    {
        _image.color = value;
    }

    #endregion
}