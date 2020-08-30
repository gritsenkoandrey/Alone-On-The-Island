using System;
using UnityEngine;
using Random = UnityEngine.Random;


public sealed class Aim : BaseObjectScene, ICollision, ISelectObj, ISelectObjImage
{
    #region Fields

    [SerializeField] private float _hp = 100;
    private readonly float _timeToDestroy = 2.0f;
    private readonly float _scaleTarget = 0.01f;
    private bool _isDead;

    [SerializeField] private ParticleSystem _particleExplosion;
    [SerializeField] private AudioClip[] _clips;
    private AudioSource _audioSource;
    private ShakeMainCamera _shakeCamera;

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
        _audioSource = GetComponent<AudioSource>();
        _shakeCamera = Camera.main.GetComponent<ShakeMainCamera>();
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
            //if (!TryGetComponent<Rigidbody>(out _))
            //{
            //    gameObject.AddComponent<Rigidbody>();
            //}
            //if (TryGetComponent<AudioSource>(out var i))
            //{
            //    i.PlayOneShot(_clips[Random.Range(0, _clips.Length)]);
            //}
            //GetComponent<Animator>().enabled = false;
            _shakeCamera.ShakeCamera();
            ExplosionSound();
            Instantiate(_particleExplosion, transform.position, transform.rotation);
            OnPointChange.Invoke();
            _isDead = true;
            DestroyCube();
        }
    }

    public string GetMessage()
    {
        if (CurrentHealth > 0)
        {
            return $"{Name} - {CurrentHealth:0}";
        }
        else
        {
            return $"{LangManager.Instance.Text("PauseMenu", "TargetDestroyed")}";
            //return "Target Destroyed";
        }
    }

    public float GetImage()
    {
        return FillHealth;
    }

    private void ExplosionSound()
    {
        _audioSource.PlayOneShot(_clips[Random.Range(0, _clips.Length)]);
    }

    private void DestroyCube()
    {
        gameObject.transform.localScale = new Vector3(_scaleTarget, _scaleTarget, _scaleTarget);
        Destroy(gameObject, _timeToDestroy);
    }

    #endregion
}