using UnityEngine;


public abstract class BaseMenu : MonoBehaviour
{
    #region Fields

    protected Interface Interface;

    #endregion


    #region Properties

    protected bool IsShow { get; set; }

    #endregion


    #region UnityMethods

    protected virtual void Awake()
    {
        Interface = FindObjectOfType<Interface>();
    }

    #endregion


    #region Methods

    public abstract void Hide();
    public abstract void Show();

    #endregion
}