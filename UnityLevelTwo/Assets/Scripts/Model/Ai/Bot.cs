using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public sealed class Bot : BaseObjectScene, IExecute
{
    #region Fields

    public float Hp = 100.0f;
    public Vision Vision;
    //public Weapon Weapon;
    private UnitAnimator _animator;
    private DeathBot _deathBot;

    private Vector3 _point;
    private float _stoppingDistance = 2.0f;
    private float _stoppingMoveDistance = 2.5f;
    private float _waitTime = 3.0f;
    private float _timeToDestroy = 5.5f;
    private float _detectedDistance = 30.0f;
    private float _distance;
    //private float _attackDistance = 5.0f;

    private StateBot _stateBot;
    private ITimeRemaining _timeRemaining;
    public event Action<Bot> OnDieChange;

    public event Action OnFireEnableChange = delegate { };
    public event Action OnFireDisableChange = delegate { };

    public event Action OnDyingEnableChange = delegate { };
    public event Action OnDyingDisableChange = delegate { };

    public event Action HitReactionEnable = delegate { };
    public event Action HitReactionDisable = delegate { };

    #endregion


    #region Properties

    // нужно сделать internal поле
    public float CurrentHealth { get; set; }

    public float FillHealth
    {
        get { return CurrentHealth / Hp; }
    }
    public Transform Target { get; set; }
    public NavMeshAgent Agent { get; private set; }
    private StateBot StateBot
    {
        get { return _stateBot; }
        set
        {
            _stateBot = value;
            switch (value)
            {
                case StateBot.None:
                    Color = Color.white;
                    break;
                case StateBot.Patrol:
                    Color = Color.green;
                    break;
                case StateBot.Inspection:
                    Color = Color.yellow;
                    break;
                case StateBot.Detected:
                    Color = Color.red;
                    break;
                case StateBot.Died:
                    Color = Color.gray;
                    break;
                default:
                    Color = Color.white;
                    break;
            }
        }
    }

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();
        Agent = GetComponent<NavMeshAgent>();
        _timeRemaining = new TimeRemaining(ResetStateBot, _waitTime);
        CurrentHealth = Hp;
        _animator = GetComponent<UnitAnimator>();
        _deathBot = GetComponent<DeathBot>();
        //SetKinematic(true);
    }

    private void OnEnable()
    {
        var bodyBot = GetComponentInChildren<BodyBot>();
        if (bodyBot != null)
        {
            bodyBot.OnApplyDamageChange += SetDamage;
        }

        var headBot = GetComponentInChildren<HeadBot>();
        if (headBot != null)
        {
            headBot.OnApplyDamageChange += SetDamage;
        }
    }

    private void OnDisable()
    {
        var bodyBot = GetComponentInChildren<BodyBot>();
        if (bodyBot != null)
        {
            bodyBot.OnApplyDamageChange -= SetDamage;
        }

        var headBot = GetComponentInChildren<HeadBot>();
        if (headBot != null)
        {
            headBot.OnApplyDamageChange -= SetDamage;
        }
    }

    #endregion


    #region Methods

    public void Execute()
    {
        // паттерн State
        if (StateBot == StateBot.Died)
        {
            return;
        }

        if (Agent.hasPath)
        {
            _animator.MovingAnim();

            if(Vector3.Distance(transform.position, Target.position) <= _stoppingMoveDistance)
            {
                _animator.StopMovingAnim();
            }
        }
        else
        {
            _animator.StopMovingAnim();
        }

        if (StateBot != StateBot.Detected)
        {
            if (!Agent.hasPath)
            {
                if (StateBot != StateBot.Inspection)
                {
                    
                    if (StateBot != StateBot.Patrol)
                    {
                        StateBot = StateBot.Patrol;
                        _point = Patrol.GenericPoint(transform);
                        MovePoint(_point);
                        Agent.stoppingDistance = 0;
                    }
                    else
                    {
                        if ((_point - transform.position).sqrMagnitude <= 1)
                        {
                            StateBot = StateBot.Inspection;
                            _timeRemaining.AddTimeRemaining();
                        }
                    }
                }
            }
            if (Vision.VisionM(transform, Target))
            {
                StateBot = StateBot.Detected;
            }
        }
        else
        {
            if (Math.Abs(Agent.stoppingDistance - _stoppingDistance) > Mathf.Epsilon)
            {
                Agent.stoppingDistance = _stoppingDistance;
            }

            if (Vision.VisionM(transform, Target))
            {
                // для ближней атаки
                //if (Vector3.Distance(transform.position, Target.position) <= _attackDistance)
                //{
                //    OnFireEnableChange.Invoke();
                //}
                //OnFireDisableChange.Invoke();
                //MovePoint(Target.position);
                //Weapon.Fire();

                // временная заглушка
                return;
            }
            else
            {
                MovePoint(Target.position);
            }

            if (ChangeState())
            {
                _point = Patrol.GenericPoint(transform);
                MovePoint(_point);
                Agent.stoppingDistance = 0;
            }
        }
    }

    private void ResetStateBot()
    {
        StateBot = StateBot.None;
    }

    private void SetDamage(InfoCollision info)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth -= info.Damage;
            HitReactionEnable?.Invoke();
            if (info.Damage > 0 /*&& info.ObjCollision == Target*/)
            {
                StateBot = StateBot.Detected;
            }
        }
        HitReactionDisable?.Invoke();

        if (CurrentHealth <= 0)
        {
            StateBot = StateBot.Died;
            Agent.enabled = false;
            //DieRagdoll();
            DyingBot();
        }
    }

    public void MovePoint(Vector3 point)
    {
        Agent.SetDestination(point);
    }

    private bool ChangeState()
    {
        if (StateBot == StateBot.Detected)
        {
            _distance = Vector3.Distance(transform.position, Target.position);
            if (_distance > _detectedDistance)
            {
                StateBot = StateBot.Patrol;
                return true;
            }
        }
        return false;
    }

    public void DyingBot(/*InfoCollision info*/)
    {
        //foreach (var child in GetComponentsInChildren<Transform>())
        //{
        //    //child.parent = null;
        //    //var tempRbChild = child.GetComponent<Rigidbody>();
        //    //if (!tempRbChild)
        //    //{
        //    //    tempRbChild = child.gameObject.AddComponent<Rigidbody>();
        //    //}
        //    //tempRbChild.AddForce(info.Direction * Random.Range(1, 100));
        //}
        OnDieChange?.Invoke(this);
        StartCoroutine(_deathBot.DeathPartical());
        OnDyingEnableChange.Invoke();
        Destroy(gameObject, _timeToDestroy);
        OnDyingDisableChange.Invoke();
    }

    //private void SetKinematic(bool newValue)
    //{
    //    var bodies = GetComponentsInChildren<Rigidbody>();
    //    foreach (var body in bodies)
    //    {
    //        body.isKinematic = newValue;
    //    }
    //}

    //public void DieRagdoll()
    //{
    //    SetKinematic(false);
    //    GetComponent<Animator>().enabled = false;
    //    Destroy(gameObject, _timeToDestroy);
    //}

    #endregion
}