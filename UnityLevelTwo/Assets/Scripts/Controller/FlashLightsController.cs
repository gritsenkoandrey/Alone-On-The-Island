using UnityEngine;


public sealed class FlashLightsController : BaseController, IExecute, IInitialization
{
    #region Fields

    private FlashLightModel _flashLightModel;

    #endregion


    #region Methods

    // awake
    public void Initialization()
    {
        _flashLightModel = Object.FindObjectOfType<FlashLightModel>();

        UiInterface.LightUiText.SetActive(false);
        UiInterface.LightUiBar.SetActive(false);
    }

    public override void On()
    {
        if (IsActive)
        {
            return;
        }

        if (_flashLightModel.BatteryChargeCurrent <= 0)
        {
            return;
        }

        base.On();

        _flashLightModel.Switch(FlashLightActiveType.On);
        UiInterface.LightUiText.SetActive(true);
        UiInterface.LightUiBar.SetActive(true);
        UiInterface.LightUiBar.SetColor(Color.green);
    }

    //public override void On(params BaseObjectScene[] flashLight)
    //{
    //    if (IsActive)
    //    {
    //        return;
    //    }

    //    if (flashLight.Length > 0)
    //    {
    //        _flashLightModel = flashLight[0] as FlashLightModel;
    //    }

    //    if (_flashLightModel == null)
    //    {
    //        return;
    //    }

    //    if (_flashLightModel.BatteryChargeCurrent <= 0)
    //    {
    //        return;
    //    }

    //    base.On();

    //    _flashLightModel.Switch(FlashLightActiveType.On);
    //    UiInterface.LightUiText.SetActive(true);
    //    UiInterface.LightUiBar.SetActive(true);
    //    UiInterface.LightUiBar.SetColor(Color.green);
    //}

    public override void Off()
    {
        if (!IsActive)
        {
            return;
        }

        base.Off();

        _flashLightModel.Switch(FlashLightActiveType.Off);
        UiInterface.LightUiText.SetActive(false);
        UiInterface.LightUiBar.SetActive(false);
    }

    // update
    public void Execute()
    {
        // Adding battery power
        if (!IsActive && _flashLightModel.AddBatteryCharge())
        {
            return;
        }

        if (_flashLightModel.EditBatteryCharge())
        {
            UiInterface.LightUiText.Text = _flashLightModel.BatteryChargeCurrent;
            UiInterface.LightUiBar.Fill = _flashLightModel.Charge;
            _flashLightModel.Rotation();

            if (_flashLightModel.LowBattery())
            {
                UiInterface.LightUiBar.SetColor(Color.red);
            }
        }
        else
        {
            Off();
        }
    }

    #endregion
}