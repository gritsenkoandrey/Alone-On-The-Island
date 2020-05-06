using System.Collections.Generic;
using UnityEngine;


public abstract class Weapon : BaseObjectScene
{
    #region Fields

    // конкретная пуля
    public Ammunition Ammunition;
    public AmmunitionRPG AmmunitionRPG;
    // от куда вылетает снаряд
    //[SerializeField] protected Transform _barrel;
    [SerializeField] protected Transform _barrelOne;
    [SerializeField] protected Transform _barrelTwo;
    [SerializeField] protected Transform _barrelThree;

    // структура которая содержит количество патронов в обойме
    public Clip Clip;
    // очередь с нашими обоймами
    private Queue<Clip> _clips = new Queue<Clip>();

    // сила полета пули
    [SerializeField] protected float _force = 999.0f;
    // время перезарядки
    [SerializeField] protected float _rechargeTime = 0.2f;
    private int _maxCountAmmunition = 40;
    private int _minCountAmmunition = 20;
    // количество обойм в оружии
    private int _countClip = 5;
    // готовность стрельбы
    protected bool _isReady = true;

    public AmmunitionType[] AmmunitionTypes = { AmmunitionType.Bullet, AmmunitionType.Rpg };

    // объект который отсчитывает время между выстрелами
    protected ITimeRemaining _timeRemaining;

    #endregion


    #region Properties

    // количество обойм
    public int CountClip
    {
        get { return _clips.Count; }
    }

    #endregion


    #region UnityMethods

    private void Start()
    {
        // передаю таймремаининг + проверяется готовность на стрельбу с отсчитыванием времени
        _timeRemaining = new TimeRemaining(ReadyShoot, _rechargeTime);
        for (var i = 0; i <= _countClip; i++)
        {
            AddClip(new Clip { CountAmmunition = Random.Range(_minCountAmmunition, _maxCountAmmunition) });
        }
        ReloadClip();

        // если сделать так то контроллер подхватит таймер и начнет его отсчитывать
        //_timeRemaining.AddTimeRemaining();
    }

    #endregion


    #region Methods

    public abstract void Fire();

    protected void ReadyShoot()
    {
        _isReady = true;
    }

    protected void AddClip(Clip clip)
    {
        _clips.Enqueue(clip);
    }

    public void ReloadClip()
    {
        if (CountClip <= 0)
        {
            return;
        }
        Clip = _clips.Dequeue();
    }

    #endregion
}