using UnityEngine;
using UnityEngine.UI;


public class PlayerUiText : MonoBehaviour
{
    #region Fields

    private Text _text;

    #endregion


    #region Properties

    public float Text
    {
        set
        {
            _text.text = $"Health : {value:0}%";
        }
    }

    #endregion


    #region UnityMethods

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    #endregion


    #region Methods

    public void SetActive(bool value)
    {
        _text.gameObject.SetActive(value);
    }

    #endregion
}