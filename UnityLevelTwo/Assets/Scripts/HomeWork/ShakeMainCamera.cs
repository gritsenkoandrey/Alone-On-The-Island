using UnityEngine;

public sealed class ShakeMainCamera : BaseObjectScene
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
    }

    public void ShakeCamera()
    {
        _animator.SetTrigger("Shake");
    }
}