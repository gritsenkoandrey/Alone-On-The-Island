using System;
using UnityEngine;


public sealed class HeadBot : MonoBehaviour, ICollision
{
    #region Fields

    public event Action<InfoCollision> OnApplyDamageChange;

    #endregion

    #region Methods

    public void CollisionEnter(InfoCollision info)
    {
        OnApplyDamageChange?.Invoke(new InfoCollision
            (info.Damage * 500, info.Contact, info.ObjCollision, info.Direction));
    }

    #endregion
}