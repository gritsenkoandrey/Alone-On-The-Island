using UnityEngine.UI;


public sealed class FlashLightUiText : BaseObjectScene
{
    #region Fields

    private Text _text;

    #endregion


    #region Properties

    public float Text
    {
        //set => _text.text = $"{value:0.0}";
        set
        {
            _text.text = $"{value:0.0}";
            //_text.text = null;
        }
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

    public new void SetActive(bool value)
    {
        _text.gameObject.SetActive(value);
    }

    #endregion
}