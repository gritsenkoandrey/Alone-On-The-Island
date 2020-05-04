﻿public abstract class BaseController
{
    #region Fields

    protected UiInterface UiInterface;

    #endregion


    #region ClassLifeCycles

    protected BaseController()
    {
        UiInterface = new UiInterface();
    }

    #endregion


    #region Properties

    public bool IsActive { get; private set; }

    #endregion


    #region Methods

    public virtual void On()
    {
        On(null);
    }

    public virtual void On(params BaseObjectScene[] obj)
    {
        IsActive = true;
    }

    public virtual void Off()
    {
        IsActive = false;
    }

    public void Switch(params BaseObjectScene[] obj)
    {
        if (!IsActive)
        {
            On();
        }
        else
        {
            Off();
        }
    }

    #endregion
}