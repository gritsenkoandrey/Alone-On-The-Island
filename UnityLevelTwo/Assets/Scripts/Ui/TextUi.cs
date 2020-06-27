using UnityEngine;
using UnityEngine.UI;


public class TextUi : MonoBehaviour, IControl
{
    #region Fields

    private Text _text;

    #endregion


    #region Properties

    public Text GetText
    {
        get
        {
            if (!_text)
            {
                _text = transform.GetComponentInChildren<Text>();
            }
            return _text;
        }
    }

    public GameObject Instance { get { return gameObject; } }
    public Selectable Control { get; }

    #endregion


    #region UnityMethods

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
    }

    #endregion

}