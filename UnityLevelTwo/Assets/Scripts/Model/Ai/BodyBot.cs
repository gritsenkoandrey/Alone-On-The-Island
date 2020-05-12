using System;
using UnityEngine;


public sealed class BodyBot : BaseObjectScene, ICollision, ISelectObj, ISelectObjImage
{
    private Bot _bot;

    #region Fields

    public event Action<InfoCollision> OnApplyDamageChange;

    #endregion

    protected override void Awake()
    {
        //_bot = GetComponent<Bot>();
        _bot = GetComponentInParent<Bot>();

    }

    #region Methods

    public void CollisionEnter(InfoCollision info)
    {
        OnApplyDamageChange?.Invoke(new InfoCollision
            (info.Damage, info.Contact, info.ObjCollision, info.Direction));
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