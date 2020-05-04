using UnityEngine;
using UnityEngine.UI;


public sealed class FlashLightUiBar : MonoBehaviour
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

    private void Awake()
    {
        _bar = GetComponent<Image>();
    }

    #endregion


    #region Methods

    public void SetActive(bool value)
    {
        _bar.gameObject.SetActive(value);
    }

    public void SetColor(Color value)
    {
        _bar.color = value;
    }

    #endregion
}