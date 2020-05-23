using UnityEngine;
using UnityEngine.UI;


public sealed class WeaponUiText : BaseObjectScene
{
    #region Fields

    private Text _text;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();

        _text = GetComponent<Text>();
    }

    #endregion


    #region Methods

    public void ShowData(int countAmmunition, int countClip)
    {
        _text.text = $"{countAmmunition}/{countClip}";
    }

    public new void SetActive(bool value)
    {
        _text.gameObject.SetActive(value);
    }

    #endregion
}