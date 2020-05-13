using System;


public sealed class HeadBot : BaseObjectScene, ICollision, ISelectObj, ISelectObjImage
{
    #region Fields

    private Bot _bot;
    public event Action<InfoCollision> OnApplyDamageChange;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        _bot = GetComponentInParent<Bot>();
    }

    #endregion


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
            return $"{Name} - {_bot.CurrentHealth}";

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