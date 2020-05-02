using UnityEngine;
using UnityEngine.UI;


public sealed class FlashLightUi : MonoBehaviour
{
    #region Fields

    private Text _text;
    //todo image

    #endregion


    #region Properties

    public float Text
    {
        //set => _text.text = $"{value:0.0}";
        set
        {
            _text.text = $"{value:0.0}";
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