using UnityEngine;


public abstract class AmmunitionRPG : BaseObjectScene
{
    #region Fields

    [SerializeField] private float _timeToDestruct = 2;
    [SerializeField] private float _baseDamage = 100;

    protected float _currentDamage;
    private float _lossOfDamageAtTime = 10f;

    //private ITimeRemaining _timeRemaining;

    public AmmunitionType Type = AmmunitionType.Rpg;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();
        _currentDamage = _baseDamage;
    }

    private void Start()
    {
        //Destroy(gameObject, _timeToDestruct);
        //_timeRemaining = new TimeRemaining(LossOfDamage, 0.1f, true);
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

    private void LossOfDamage()
    {
        _currentDamage -= _lossOfDamageAtTime;
        if (_currentDamage < 0)
        {
            _currentDamage = 0;
        }
    }

    //protected void DestroyAmmunition()
    //{
    //    Destroy(gameObject);
    //    _timeRemaining.RemoveTimeRemaining();
    //}
    protected void DestroyAmmunition(float timeToDestruct = 0)
    {
        Destroy(gameObject, timeToDestruct);
        CancelInvoke(nameof(LossOfDamage));
        // todo вернуть в пул
    }


    #endregion
}