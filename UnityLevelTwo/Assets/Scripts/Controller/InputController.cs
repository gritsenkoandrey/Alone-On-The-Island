using UnityEngine;


public sealed class InputController : BaseController, IExecute
{
    #region Fields

    private readonly KeyCode _activeFlashLight = KeyCode.F;
    private readonly KeyCode _cancel = KeyCode.Escape;
    private readonly KeyCode _reloadClip = KeyCode.R;
    private readonly KeyCode _removeWeapon = KeyCode.T;
    private readonly KeyCode _savePlayer = KeyCode.Z;
    private readonly KeyCode _loadPlayer = KeyCode.X;
    private readonly KeyCode _screenShot = KeyCode.C;
    private readonly int _mouseButton = (int)MouseButton.LeftButton;

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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectWeapon(2);
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
            ServiceLocator.Resolve<PauseController>().On();
        }

        if (Input.GetKeyDown(_reloadClip))
        {
            if (ServiceLocator.Resolve<WeaponController>().IsActive)
            {
                ServiceLocator.Resolve<WeaponController>().ReloadClip();
            }
        }

        if (Input.GetKeyDown(_removeWeapon))
        {
            ServiceLocator.Resolve<WeaponController>().Off();
            ServiceLocator.Resolve<Inventory>().RemoveWeapon();
        }

        // todo manager
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            MouseScroll(MouseScrollWheel.Up);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            MouseScroll(MouseScrollWheel.Down);
        }

        if (Input.GetKeyDown(_savePlayer))
        {
            ServiceLocator.Resolve<SaveDataRepository>().Save();
        }

        if (Input.GetKeyDown(_loadPlayer))
        {
            ServiceLocator.Resolve<SaveDataRepository>().Load();
        }

        if (Input.GetKeyDown(_screenShot))
        {
            //ServiceLocator.Resolve<PhotoController>().FirstMethod();
            //ServiceLocator.Resolve<PhotoController>().SecondMethod();
            ServiceLocator.Resolve<MyPhotoController>().CaptureRenderTexture();
        }
    }

    private void SelectWeapon(int index)
    {
        var tempWeapon = ServiceLocator.Resolve<Inventory>().SelectWeapon(index);
        SelectWeapon(tempWeapon);

        //ServiceLocator.Resolve<WeaponController>().Off();
        //var tempWeapon = ServiceLocator.Resolve<Inventory>().Weapons[i]; // todo инкапсулировать
        //if (tempWeapon != null)
        //{
        //    ServiceLocator.Resolve<WeaponController>().On(tempWeapon);
        //}
    }

    private void SelectWeapon(Weapon weapon)
    {
        ServiceLocator.Resolve<WeaponController>().Off();
        if (weapon != null)
        {
            ServiceLocator.Resolve<WeaponController>().On(weapon);
        }
    }

    private void MouseScroll(MouseScrollWheel value)
    {
        var tempWeapon = ServiceLocator.Resolve<Inventory>().SelectWeapon(value);
        SelectWeapon(tempWeapon);
    }

    #endregion
}