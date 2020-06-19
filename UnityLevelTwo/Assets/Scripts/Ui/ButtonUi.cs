﻿using UnityEngine;
using UnityEngine.UI;


public sealed class ButtonUi : MonoBehaviour, IControlText
{
    #region Fields

    private Text _text;
    private Button _control;

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
    public Button GetControl
    {
        get
        {
            if (!_control)
            {
                _control = GetComponentInChildren<Button>();
            }
            return _control;
        }
    }

    public GameObject Instance { get { return gameObject; } }

    public Selectable Control { get { return GetControl; } }

    #endregion


    #region Methods

    public void SetInteractable (bool value)
    {
        GetControl.interactable = value;
    }

    #endregion
}