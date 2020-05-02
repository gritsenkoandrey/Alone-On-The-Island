using UnityEngine;


public sealed class InputController : BaseController, IExecute
{
    #region Fields

    private KeyCode _activeFlashLight = KeyCode.F;

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
            ServiceLocator.Resolve<FlashLightsController>().Switch();
        }
    }

    #endregion
}