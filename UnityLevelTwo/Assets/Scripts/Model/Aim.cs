using System;
using UnityEngine;


public sealed class Aim : BaseObjectScene, ICollision, ISelectObj, ISelectObjImage
{
    #region Fields

    [SerializeField] private float _hp = 100;
    private readonly float _timeToDestroy = 10.0f;

    private bool _isDead;

    public event Action OnPointChange = delegate { };

    #endregion


    #region Properties

    public float CurrentHealth { get; private set; }

    public float FillHealth
    {
        get { return CurrentHealth / _hp; }
    }

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();
        CurrentHealth = _hp;
    }

    #endregion


    #region Methods

    // дописать поглощение урона
    public void CollisionEnter(InfoCollision info)
    {
        if (_isDead)
        {
            return;
        }
        if (CurrentHealth > 0)
        {
            CurrentHealth -= info.Damage;
        }
        if (CurrentHealth <= 0)
        {
            if (!TryGetComponent<Rigidbody>(out _))
            {
                gameObject.AddComponent<Rigidbody>();
            }
            Destroy(gameObject, _timeToDestroy);
            OnPointChange.Invoke();
            _isDead = true;
        }
    }

    public string GetMessage()
    {
        if (CurrentHealth > 0)
        {
            return $"{Name} - {CurrentHealth}";
        }
        else
        {
            return "Target Destroyed";
        }
    }

    public float GetImage()
    {
        return FillHealth;
    }

    //public bool LowHealth()
    //{
    //    return CurrentHealth <= _hp / 2.0f;
    //}

    #endregion
}