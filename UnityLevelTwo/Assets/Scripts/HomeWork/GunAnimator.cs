using UnityEngine;


public class GunAnimator : BaseObjectScene
{
    private Weapon _weapon;
    private Animator _animator;
    private static readonly int FireEnable = Animator.StringToHash("FireEnabled");
    private static readonly int FireDisable = Animator.StringToHash("FireDisabled");
    private static readonly int ReloadOn = Animator.StringToHash("ReloadOn");
    private static readonly int ReloadOff = Animator.StringToHash("ReloadOff");

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        _weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (ServiceLocator.Resolve<WeaponController>().IsActive && _weapon.Clip.CountAmmunition > 0)
            {
                FireOn();
            }
        }
        else
        {
            FireOff();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            if(ServiceLocator.Resolve<WeaponController>().IsActive && _weapon.CountClip > 0)
            {
                ReloadClipOn();
            }
        }
        else
        {
            ReloadClipOff();
        }
    }

    private void FireOn()
    {
        _animator.SetTrigger(FireEnable);
    }

    private void FireOff()
    {
        _animator.SetTrigger(FireDisable);
    }

    private void ReloadClipOn()
    {
        _animator.SetTrigger(ReloadOn);
    }

    private void ReloadClipOff()
    {
        _animator.SetTrigger(ReloadOff);
    }
}