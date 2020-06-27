using UnityEngine;


public abstract class Ammunition : BaseObjectScene
{
    #region Fields

    [SerializeField] private float _timeToDestruct = 10;
    [SerializeField] private float _baseDamage = 10;
    protected float _currentDamage;
    private float _lossOfDamageAtTime = 0.2f;

    //private ITimeRemaining _timeRemaining;
    public AmmunitionType Type = AmmunitionType.Bullet;

    [SerializeField] protected ParticleSystem _particleSystem;
    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();
        _currentDamage = _baseDamage;
        //DestroyAmmunition(_timeToDestruct);
        //InvokeRepeating(nameof(LossOfDamage), 0.5f, 1);
    }

    private void Start()
    {
        //Destroy(gameObject, _timeToDestract);
        //// каждую секунду наш урон будет уменьшаться
        //_timeRemaining = new TimeRemaining(LossOfDamage, 1.0f, true);
        //// добавляем его в счетчик времени
        //_timeRemaining.AddTimeRemaining();

        DestroyAmmunition(_timeToDestruct);
        InvokeRepeating(nameof(LossOfDamage), 0.5f, 1);
    }

    #endregion


    #region Methods

    public void AddForce(Vector3 direction)
    {
        if (!Rigidbody)
        {
            return;
        }
        Rigidbody.AddForce(direction);
    }

    // потеря урона полуй
    private void LossOfDamage()
    {
        _currentDamage -= _lossOfDamageAtTime;
    }

    //protected void DestroyAmmunition()
    //{
    //    Destroy(gameObject);
    //    _timeRemaining.RemoveTimeRemaining();
    //    // todo вернуть в пул
    //}

    protected void DestroyAmmunition(float timeToDestruct = 0)
    {
        Destroy(gameObject, timeToDestruct);
        CancelInvoke(nameof(LossOfDamage));
        // todo вернуть в пул
    }

    #endregion
}