using UnityEngine;
using UnityEngine.UI;


public sealed class ChangeHealthUi : BaseObjectScene
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

    public void DamageTaken(float value)
    {
        _text.color = Color.red;
        _text.text = $"-{value:0}";
    }

    public void HealthTaken(float value)
    {
        _text.color = Color.green;
        _text.text = $"+{value:0}";
    }

    public void Clear()
    {
        _text.text = null;
    }

    #endregion
}