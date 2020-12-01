using UnityEngine.UI;


public class PlayerUiText : BaseObjectScene
{
    #region Fields

    private Text _text;

    #endregion


    #region Properties

    public float Text
    {
        set
        {
            _text.text = $"{value:0}%";
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
}