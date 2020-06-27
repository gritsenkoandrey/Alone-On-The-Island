using UnityEngine;
using UnityEngine.SceneManagement;


public sealed class Player : BaseObjectScene, ICollision
{
    #region Fields

    [SerializeField] internal float maxHealth = 50.0f;
    [SerializeField] private AudioClip[] _clips;
    [SerializeField] private AudioClip[] _jumpClips;
    private AudioSource _audioSource;
    private CharacterController _controller;
    private ChangeHealthUi _changeHealthUi;

    internal readonly float minHealth = 0;
    private readonly float _quarter = 0.25f;
    private readonly float _displayTimer = 0.5f;
    internal float CurrentHealth;
    private readonly int _minIndexArray = 0;
    private bool _isDead = false;

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
        _audioSource = GetComponent<AudioSource>();
        _controller = GetComponent<CharacterController>();
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
        }
    }

    public void FootSteps()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || 
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (_controller.isGrounded)
            {
                if (!_audioSource.isPlaying)
                {
                    _audioSource.PlayOneShot(_clips[Random.Range(_minIndexArray,_clips.Length)]);
                }
            }
        }
    }

    public void JumpSound()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_controller.isGrounded)
            {
                _audioSource.PlayOneShot(_jumpClips[Random.Range(_minIndexArray, _jumpClips.Length)]);
            }
        }
    }

    #endregion
}