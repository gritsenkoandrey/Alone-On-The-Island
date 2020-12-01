using UnityEngine;
using UnityEngine.UI;


public sealed class AimUiImage : BaseObjectScene
{
    #region Fields

    private Image _bar;
    private Animator _animator;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();

        _bar = GetComponent<Image>();
        _animator = GetComponent<Animator>();
    }

    #endregion


    #region Methods

    public new void SetActive(bool value)
    {
        _bar.gameObject.SetActive(value);
    }

    public void SetColor(Color value)
    {
        _bar.color = value;
    }

    public void SetAnimOn()
    {
        _animator.SetTrigger("TargetOn");
    }

    public void SetAnimOff()
    {
        _animator.SetTrigger("TargetOff");
    }

    #endregion
}