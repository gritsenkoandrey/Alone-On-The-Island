using UnityEngine;


public abstract class AmmunitionRPG : BaseObjectScene
{
    #region Fields

    [SerializeField] private float _timeToDestract = 5;
    [SerializeField] private float _baseDamage = 100;

    protected float _currentDamage;
    private float _lossOfDamageAtTime = 10f;

    private ITimeRemaining _timeRemaining;

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
        Destroy(gameObject, _timeToDestract);
        _timeRemaining = new TimeRemaining(LossOfDamage, 0.1f, true);
        _timeRemaining.AddTimeRemaining();
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
    }

    protected void DestroyAmmunition()
    {
        Destroy(gameObject);
        _timeRemaining.RemoveTimeRemaining();
    }

    #endregion
}