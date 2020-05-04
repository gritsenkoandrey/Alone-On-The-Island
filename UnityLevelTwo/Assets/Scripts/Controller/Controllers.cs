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
        IMotor motor = default;

        if (Application.platform == RuntimePlatform.Android)
        {
            //
        }

        else
        {
            motor = new UnitMotor(ServiceLocatorMonoBehaviour.GetService<CharacterController>());
        }
        ServiceLocator.SetService(new PlayerController(motor));
        ServiceLocator.SetService(new FlashLightsController());
        ServiceLocator.SetService(new InputController());
        ServiceLocator.SetService(new SelectionController());

        _executeControllers = new IExecute[4];
        _executeControllers[0] = ServiceLocator.Resolve<PlayerController>();
        _executeControllers[1] = ServiceLocator.Resolve<FlashLightsController>();
        _executeControllers[2] = ServiceLocator.Resolve<InputController>();
        _executeControllers[3] = ServiceLocator.Resolve<SelectionController>();
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

        ServiceLocator.Resolve<PlayerController>().On();
        ServiceLocator.Resolve<InputController>().On();
        ServiceLocator.Resolve<SelectionController>().On();
    }

    #endregion
}