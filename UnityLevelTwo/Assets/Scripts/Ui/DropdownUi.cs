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
    public Dropdown GetControl
    {
        get
        {
            if (!_control)
            {
                _control = GetComponentInChildren<Dropdown>();
            }
            return _control;
        }

        set
        {
            value = _control;
        }
    }
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

    public void ChangeLanguage()
    {
        if (_control.value == 0)
        {
            LangManager.Instance.Init("Language", "Ru");
        }
        else
        {
            LangManager.Instance.Init("Language", "En");
        }
    }

    #endregion
}