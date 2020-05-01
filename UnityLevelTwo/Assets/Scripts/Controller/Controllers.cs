﻿using UnityEngine;


public sealed class Controllers : IInitialization
{
    private readonly IExecute[] _executeControllers;

    public int Length => _executeControllers.Length;

    public IExecute this[int index] => _executeControllers[index];

    public Controllers()
    {
        IMotor motor = default;

        if (Application.platform == RuntimePlatform.PS4)
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

        _executeControllers = new IExecute[3];
        _executeControllers[0] = ServiceLocator.Resolve<PlayerController>();
        _executeControllers[1] = ServiceLocator.Resolve<FlashLightsController>();
        _executeControllers[2] = ServiceLocator.Resolve<InputController>();
    }

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
    }
}