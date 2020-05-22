using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : BaseObjectScene, ICollision
{
    #region Fields

    [SerializeField] private float _maxHealth = 500;
    private readonly float _minHealth = 0;
    private readonly float _quarter = 0.25f;
    private bool _isDead = false;

    #endregion


    #region Properties

    public float CurrentHealth { get; private set; }

    public float FillHealth
    {
        get { return CurrentHealth / _maxHealth; }
    }

    public float AverageHealth
    {
        get { return _maxHealth * _quarter; }
    }

    public float PercentHealth
    {
        get
        {
            if (CurrentHealth <= 0)
            {
                return 0;
            }
            else
            {
                return (CurrentHealth / _maxHealth) * 100;
            }
        }
    }

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();
        CurrentHealth = _maxHealth;
    }

    #endregion


    #region Methods

    public void CollisionEnter(InfoCollision info)
    {
        if (_isDead)
        {
            return;
        }

        if (CurrentHealth > _minHealth)
        {
            CurrentHealth -= info.Damage;
            Debug.Log(CurrentHealth);
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