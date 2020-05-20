using System;
using UnityEngine;
using static UnityEngine.Random;

public sealed class Wall : BaseObjectScene, ISelectObj, ISelectObjImage, ICollision
{
    #region Fields

    [SerializeField] private float _hp = 100;
    private float _timeToDestroy = 5.0f;

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
        CurrentHealth = _hp;
    }

    #endregion


    #region Methods

    // дописать поглощение урона
    public  void CollisionEnter(InfoCollision info)
    {
        if (_isDead)
        {
            return;
        }
        if (CurrentHealth > 0)
        {
            CurrentHealth -= info.Damage;
            if (!TryGetComponent<Transform>(out _))
            {
                Debug.Log(gameObject);
                gameObject.AddComponent<Transform>();
            }
            //gameObject.transform.localScale = new Vector3(Range(5.0f, 15.0f), Range(2.5f, 7.0f), 1.0f);
            gameObject.transform.localScale -= new Vector3(0.5f, 0.25f, 0);
        }
        if (CurrentHealth <= 0)
        {
            if (!TryGetComponent<Rigidbody>(out _))
            {
                gameObject.AddComponent<Rigidbody>();
            }

            //if (!TryGetComponent<Transform>(out _))
            //{
            //    gameObject.AddComponent<Transform>();
            //}
            //gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            Destroy(gameObject, _timeToDestroy);
            OnPointChange.Invoke();
            _isDead = true;
        }
    }

    public string GetMessage()
    {
        if (CurrentHealth > 0)
        {
            return $"{gameObject.name} - {CurrentHealth:0}";
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

    #endregion
}