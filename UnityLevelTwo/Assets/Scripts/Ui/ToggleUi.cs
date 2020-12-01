using UnityEngine;
using UnityEngine.UI;


public class ToggleUi : MonoBehaviour
{
    #region Fields

    private Text _text;
    private Toggle _control;

    #endregion


    #region Properties

    public Text GetText { get { return _text; } }
    public Toggle GetControl { get { return _control; } }
    public GameObject Instance { get { return gameObject; } }
    public Selectable Control { get { return GetControl; } }

    #endregion


    #region UnityMethods

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
        _control = GetComponentInChildren<Toggle>();
    }

    #endregion


    #region Methods

    public void Interactable(bool value)
    {
        GetControl.interactable = value;
    }

    #endregion
}