using UnityEngine;


public sealed class ShakeMainCamera : BaseObjectScene
{
    #region Fields

    private Animator _animator;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
    }

    #endregion


    #region Methods

    public void ShakeCamera()
    {
        _animator.SetTrigger("Shake");
    }

    #endregion
}