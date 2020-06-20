using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DropdownUi : MonoBehaviour, IControl
{
    #region Fields

    private Text _text;
    private Dropdown _control;

    #endregion


    #region Properties

    public Text GetText { get { return _text; } }
    public Dropdown GetControl { get { return _control; } }
    public GameObject Instance { get { return gameObject; } }
    public Selectable Control { get { return GetControl; } }

    #endregion


    #region UnityMethods

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
        _control = GetComponentInChildren<Dropdown>();
    }

    #endregion


    #region Methods

    public void Interactable(bool value)
    {
        GetControl.interactable = value;
    }

    public void ClearResolutionList()
    {
        _control.ClearOptions();
    }

    public void AddResolutionList(List<string> value)
    {
        _control.AddOptions(value);
    }
    #endregion
}