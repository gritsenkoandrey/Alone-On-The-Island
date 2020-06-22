using UnityEngine;


public abstract class PickItems : BaseObjectScene, ISelectObj, ISelectObjImage
{
    #region Fields

    [SerializeField] private float _timeToDestruct = 0;
    protected readonly float _displayTime = 0.5f;

    protected Player _player;
    protected Bot _bot;
    protected ChangeHealthUi _changeHealthUi;
    protected AudioSource _audioSource;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();
        _changeHealthUi = FindObjectOfType<ChangeHealthUi>();
    }

    #endregion


    #region Methods

    public abstract void ExplosionSound();

    public void DestroyItem()
    {
        Destroy(gameObject, _timeToDestruct);
    }

    public string GetMessage()
    {
        return Name;
    }

    public float GetImage()
    {
        return default;
    }

    #endregion
}