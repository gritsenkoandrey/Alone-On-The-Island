using UnityEngine;


public sealed class Controllers : IInitialization
{
    #region Fields

    private readonly IExecute[] _executeControllers;

    #endregion


    #region Properties

    public int Length => _executeControllers.Length;

    public IExecute this[int index] => _executeControllers[index];

    #endregion


    #region ClassLifeCycles

    public Controllers()
    {
        IMotor motor = new UnitMotor(ServiceLocatorMonoBehaviour.GetService<CharacterController>());
        ServiceLocator.SetService(new TimeRemainingController());
        ServiceLocator.SetService(new Inventory());
        ServiceLocator.SetService(new PlayerController(motor));
        ServiceLocator.SetService(new FlashLightsController());
        ServiceLocator.SetService(new WeaponController());
        ServiceLocator.SetService(new InputController());
        ServiceLocator.SetService(new SelectionController());
        ServiceLocator.SetService(new BotController());
        ServiceLocator.SetService(new SaveDataRepository());
        ServiceLocator.SetService(new PhotoController());
        ServiceLocator.SetService(new MyPhotoController());
        ServiceLocator.SetService(new CreateObjFromResourcesController());
        ServiceLocator.SetService(new RadarController());
        ServiceLocator.SetService(new PauseController());

        _executeControllers = new IExecute[9];
        _executeControllers[0] = ServiceLocator.Resolve<PlayerController>();
        _executeControllers[1] = ServiceLocator.Resolve<FlashLightsController>();
        _executeControllers[2] = ServiceLocator.Resolve<InputController>();
        _executeControllers[3] = ServiceLocator.Resolve<SelectionController>();
        _executeControllers[4] = ServiceLocator.Resolve<TimeRemainingController>();
        _executeControllers[5] = ServiceLocator.Resolve<BotController>();
        _executeControllers[6] = ServiceLocator.Resolve<RadarController>();
        _executeControllers[7] = ServiceLocator.Resolve<WeaponController>();
        _executeControllers[8] = ServiceLocator.Resolve<PauseController>();
    }

    #endregion


    #region Methods

    public void Initialization()
    {
        foreach (var controller in _executeControllers)
        {
            if (controller is IInitialization initialization)
            {
                initialization.Initialization();
            }
        }

        ServiceLocator.Resolve<Inventory>().Initialization();
        ServiceLocator.Resolve<PlayerController>().On();
        ServiceLocator.Resolve<InputController>().On();
        ServiceLocator.Resolve<SelectionController>().On();
        ServiceLocator.Resolve<BotController>().On();
        ServiceLocator.Resolve<CreateObjFromResourcesController>().Initialization();
        ServiceLocator.Resolve<WeaponController>().Initialization();
        ServiceLocator.Resolve<PauseController>().Initialization();
    }

    public void Cleanup()
    {
        ServiceLocator.Cleanup();
        ServiceLocatorMonoBehaviour.Cleanup();
    }

    #endregion
}