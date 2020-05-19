using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : BaseObjectScene, ICollision
{
    #region Fields

    [SerializeField] private float _health = 500;
    private readonly float _minHealth = 0;
    private int _quarter = 4;
    private bool _isDead = false;

    #endregion


    #region Properties

    public float CurrentHealth { get; private set; }

    public float FillHealth
    {
        get { return CurrentHealth / _health; }
    }

    public float AverageHealth
    {
        get { return _health / _quarter; }
    }

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();
        CurrentHealth = _health;
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