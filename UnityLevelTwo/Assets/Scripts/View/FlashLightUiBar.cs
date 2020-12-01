using UnityEngine;
using UnityEngine.UI;


public sealed class FlashLightUiBar : BaseObjectScene
{
    #region Fields

    private Image _bar;

    #endregion


    #region Properties

    public float Fill
    {
        set { _bar.fillAmount = value; }
    }

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();

        _bar = GetComponent<Image>();
    }

    #endregion


    #region Methods

    public new void SetActive(bool value)
    {
        _bar.gameObject.SetActive(value);
    }

    public void SetColor(Color value)
    {
        _bar.color = value;
    }

    #endregion
}