using UnityEngine;
using UnityEngine.UI;


public class PlayerUiBar : BaseObjectScene
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

    public void SetColor(Color value)
    {
        _bar.color = value;
    }

    #endregion
}