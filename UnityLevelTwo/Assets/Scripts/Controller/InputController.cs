using UnityEngine;


public sealed class InputController : BaseController, IExecute
{
    #region Fields

    private KeyCode _activeFlashLight = KeyCode.F;
    private KeyCode _cancel = KeyCode.Escape;
    private KeyCode _reloadClip = KeyCode.R;
    private int _mouseButton = (int)MouseButton.LeftButton;

    #endregion

    #region ClassLifeCycless

    public InputController()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    #endregion


    #region Methods

    public void Execute()
    {
        if (!IsActive)
        {
            return;
        }
        if (Input.GetKeyDown(_activeFlashLight))
        {
            ServiceLocator.Resolve<FlashLightsController>().Switch(ServiceLocator.Resolve<Inventory>().FlashLight);
        }
        // реализовать выбор оружия колесиком мыши
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(0);
        }
        if (Input.GetMouseButton(_mouseButton))
        {
            if (ServiceLocator.Resolve<WeaponController>().IsActive)
            {
                ServiceLocator.Resolve<WeaponController>().Fire();
            }
        }
        if (Input.GetKeyDown(_cancel))
        {
            ServiceLocator.Resolve<WeaponController>().Off();
            ServiceLocator.Resolve<FlashLightsController>().Off();
        }
        if (Input.GetKeyDown(_reloadClip))
        {
            if (ServiceLocator.Resolve<WeaponController>().IsActive)
            {
                ServiceLocator.Resolve<WeaponController>().ReloadClip();
            }
        }
    }

    private void SelectWeapon(int i)
    {
        ServiceLocator.Resolve<WeaponController>().Off();
        var tempWeapon = ServiceLocator.Resolve<Inventory>().Weapons[i]; // todo инкапсулировать
        if (tempWeapon != null)
        {
            ServiceLocator.Resolve<WeaponController>().On(tempWeapon);
        }
    }

    #endregion
}