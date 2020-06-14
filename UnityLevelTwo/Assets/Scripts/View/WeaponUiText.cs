using UnityEngine;
using UnityEngine.UI;


public sealed class WeaponUiText : BaseObjectScene
{
    #region Fields

    private Text _text;
    private Image _image;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();

        _text = GetComponent<Text>();
        _image = GetComponent<Image>();
    }

    #endregion


    #region Methods

    public void ShowData(int countAmmunition, int maxAmunition, int countClip)
    {
        _text.text = $"{countAmmunition} - {maxAmunition} / {countClip}";
    }

    public new void SetActive(bool value)
    {
        _text.gameObject.SetActive(value);
        //_image.gameObject.SetActive(value);
    }

    #endregion
}