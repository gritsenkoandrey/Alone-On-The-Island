using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public sealed class Bot : BaseObjectScene, IExecute
{
    #region Fields

    public float Hp = 100.0f;
    public Vision Vision;
    public Weapon Weapon;

    private Vector3 _point;
    private float _stoppingDistance = 2.0f;
    private float _waitTime = 3.0f;
    private float _timeToDestroy = 10.0f;
    private float _detectedDistance = 30.0f;
    private float _distance;

    // для проверки жив ли противник
    private bool _isAlive;

    private StateBot _stateBot;
    private ITimeRemaining _timeRemaining;
    public event Action<Bot> OnDieChange;

    #endregion


    #region Properties

    public float CurrentHealth { get; private set; }

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

        if (StateBot != StateBot.Detected)
        {
            // если у бота нет пути, стоит на месте ничего не делает
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
                Weapon.Fire();
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
            if (info.Damage > 0 /*&& info.ObjCollision == Target*/)
            {
                StateBot = StateBot.Detected;
            }
        }

        if (CurrentHealth <= 0)
        {
            StateBot = StateBot.Died;
            Agent.enabled = false;
            foreach (var child in GetComponentsInChildren<Transform>())
            {
                child.parent = null;
                var tempRbChild = child.GetComponent<Rigidbody>();
                if (!tempRbChild)
                {
                    tempRbChild = child.gameObject.AddComponent<Rigidbody>();
                }
                tempRbChild.AddForce(info.Direction * Random.Range(10, 100));
                Destroy(child.gameObject, _timeToDestroy);
            }
            OnDieChange?.Invoke(this);
        }
    }

    public void MovePoint(Vector3 point)
    {
        Agent.SetDestination(point);
    }

    public bool ChangeState()
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

    #endregion
}