using UnityEngine;
using UnityEngine.UI;


public sealed class SelectionObjMessageUi : BaseObjectScene
{
    #region Fields

    private Text _text;

    #endregion


    #region Properties

    public string Text
    {
        set { _text.text = $"{value}"; }
    }

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();

        _text = GetComponent<Text>();
    }

    #endregion


    #region Methods

    public void SetColor(Color value)
    {
        _text.color = value;
    }

    #endregion
}