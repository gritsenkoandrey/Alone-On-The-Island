using UnityEngine;


public sealed class Inventory : IInitialization
{
    #region Fields

    private Weapon[] _weapons = new Weapon[5];

    #endregion


    #region Properties

    public Weapon[] Weapons
    {
        get { return _weapons; }
    }

    public FlashLightModel FlashLight { get; private set; }

    #endregion


    #region Methods

    public void Initialization()
    {
        _weapons = ServiceLocatorMonoBehaviour.GetService<CharacterController>().GetComponentsInChildren<Weapon>();
        foreach (var weapon in Weapons)
        {
            weapon.IsVisible = false;
        }

        FlashLight = Object.FindObjectOfType<FlashLightModel>();
        FlashLight.Switch(FlashLightActiveType.Off);
    }

    // todo добавить функционал
    public void RemoveWeapon (Weapon weapon)
    {

    }

    #endregion
}