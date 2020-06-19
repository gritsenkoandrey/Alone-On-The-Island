using UnityEngine;
using UnityEngine.UI;


public sealed class SliderUi : MonoBehaviour, IControl
{
    #region Fields

    private Text _text;
    private Slider _control;

    #endregion


    #region Properties

    public Text GetText { get { return _text; } }
    public Slider GetControl { get { return _control; } }
    public GameObject Instance { get { return gameObject; } }
    public Selectable Control { get { return GetControl; } }

    #endregion


    #region UnityMethods

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
        _control = GetComponentInChildren<Slider>();
    }

    #endregion


    #region Methods

    public void Interactable(bool value)
    {
        GetControl.interactable = value;
    }

    #endregion
}