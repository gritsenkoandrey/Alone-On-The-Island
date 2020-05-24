﻿using UnityEngine;
using UnityEngine.SceneManagement;


public sealed class Player : BaseObjectScene, ICollision
{
    #region Fields

    [SerializeField] internal float maxHealth = 50.0f;
    internal readonly float minHealth = 0;
    private readonly float _quarter = 0.25f;
    private readonly float _displayTimer = 0.5f;
    private bool _isDead = false;

    internal float CurrentHealth;
    private ChangeHealthUi _changeHealthUi;

    #endregion


    #region Properties

    //public float CurrentHealth { get; set; }

    public float FillHealth
    {
        get { return CurrentHealth / maxHealth; }
    }

    public float AverageHealth
    {
        get { return maxHealth * _quarter; }
    }

    public float PercentHealth
    {
        get
        {
            if (CurrentHealth <= minHealth)
            {
                return minHealth;
            }
            else
            {
                return CurrentHealth / maxHealth * 100;
            }
        }
    }

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();
        CurrentHealth = maxHealth;
        _changeHealthUi = Object.FindObjectOfType<ChangeHealthUi>();
    }

    #endregion


    #region Methods

    public void CollisionEnter(InfoCollision info)
    {
        if (_isDead)
        {
            return;
        }

        if (CurrentHealth > minHealth)
        {
            CurrentHealth -= info.Damage;
            _changeHealthUi.DamageTaken(info.Damage);
            _changeHealthUi.Invoke(nameof(_changeHealthUi.Clear), _displayTimer);

            if (CurrentHealth < minHealth)
            {
                CurrentHealth = minHealth;
            }
        }
        else
        {
            _isDead = true;
            //todo либо сцену с окончанием игры либо перзапуск сцены
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
            //ServiceLocator.Resolve<PlayerController>().Off();
        }
    }

    #endregion
}