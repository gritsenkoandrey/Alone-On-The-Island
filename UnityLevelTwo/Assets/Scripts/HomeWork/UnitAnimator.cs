using UnityEngine;
using UnityEngine.AI;


public class UnitAnimator : BaseObjectScene
{
    private Animator _animator;
    private NavMeshAgent _agent;
    private Bot _bot;

    private static readonly int Moving = Animator.StringToHash("Moving");
    private static readonly int FireEnable = Animator.StringToHash("FireEnable");
    private static readonly int FireDisable = Animator.StringToHash("FireDisable");
    private static readonly int DyingEnable = Animator.StringToHash("Dying");
    private static readonly int DyingDisable = Animator.StringToHash("Dying");
    private static readonly int ReactionOnHitEnable = Animator.StringToHash("ReactionOnHitEnable");
    private static readonly int ReactionOnHitDisable = Animator.StringToHash("ReactionOnHitDisable");

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _bot = GetComponent<Bot>();
        _bot.OnFireEnableChange += OnFireEnableChange;
        _bot.OnFireDisableChange += OnFireDisableChange;

        _bot.OnDyingEnableChange += OnDyingEnableChange;
        _bot.OnDyingDisableChange += OnDyingDisableChange;

        _bot.HitReactionEnable += HitReactionEnable;
        _bot.HitReactionDisable += HitReactionDisable;
    }

    private void OnDisable()
    {
        _bot.OnFireEnableChange -= OnFireEnableChange;
        _bot.OnFireDisableChange -= OnFireDisableChange;

        _bot.OnDyingEnableChange -= OnDyingEnableChange;
        _bot.OnDyingDisableChange -= OnDyingDisableChange;

        _bot.HitReactionEnable -= HitReactionEnable;
        _bot.HitReactionDisable -= HitReactionDisable;
    }

    public void MovingAnim()
    {
        //_animator.SetBool(Moving, _agent.hasPath);
        _animator.SetBool(Moving, true);
    }

    public void StopMovingAnim()
    {
        //_animator.SetBool(Moving, _agent.pathPending);
        _animator.SetBool(Moving, false);
    }

    private void HitReactionEnable()
    {
        _animator.SetTrigger(ReactionOnHitEnable);
    }

    private void HitReactionDisable()
    {
        _animator.SetTrigger(ReactionOnHitDisable);
    }

    private void OnFireEnableChange()
    {
        _animator.SetTrigger(FireEnable);
    }

    private void OnFireDisableChange()
    {
        _animator.SetTrigger(FireDisable);
    }

    private void OnDyingEnableChange()
    {
        _animator.SetTrigger(DyingEnable);
    }

    private void OnDyingDisableChange()
    {
        _animator.SetTrigger(DyingDisable);
    }
}