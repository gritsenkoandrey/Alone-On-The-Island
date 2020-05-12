using System;
using UnityEngine;


public sealed class HeadBot : BaseObjectScene, ICollision, ISelectObj, ISelectObjImage
{
    #region Fields

    private Bot _bot;
    public event Action<InfoCollision> OnApplyDamageChange;

    #endregion
    private void Start()
    {
        _bot = GetComponentInParent<Bot>();
    }

    #region Methods

    public void CollisionEnter(InfoCollision info)
    {
        OnApplyDamageChange?.Invoke(new InfoCollision
            (info.Damage * 500, info.Contact, info.ObjCollision, info.Direction));
    }
    public string GetMessage()
    {
        if (_bot.CurrentHealth > 0)
        {
            return $"{gameObject.name} - {_bot.CurrentHealth}";

        }
        else
        {
            return "Target Destroyed";
        }
    }

    public float GetImage()
    {
        return _bot.FillHealth;
    }

    #endregion
}