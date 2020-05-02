using UnityEngine;


public sealed class FlashLightsController : BaseController, IExecute, IInitialization
{
    private FlashLightModel _flashLightModel;
    private FlashLightUi _flashLightUi;

    // awake
    public void Initialization()
    {
        _flashLightModel = Object.FindObjectOfType<FlashLightModel>();
        _flashLightUi = Object.FindObjectOfType<FlashLightUi>();
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
        _flashLightUi.SetActive(true);
    }

    public override void Off()
    {
        if (!IsActive)
        {
            return;
        }

        base.Off();

        _flashLightModel.Switch(FlashLightActiveType.Off);
        _flashLightUi.SetActive(false);

    }

    // update
    public void Execute()
    {
        if (!IsActive)
        {
            // Adding battery power
            _flashLightModel.AddBatteryCharge();
            return;
        }

        //else
        //{
        //    // todo add Battery
        //}

        _flashLightModel.Rotation();

        if (_flashLightModel.EditBatteryCharge())
        {
            _flashLightUi.Text = _flashLightModel.BatteryChargeCurrent;
        }
        else
        {
            Off();
        }
    }
}