using UnityEngine;

public sealed class PauseController : BaseController, IInitialization, IExecute
{
    private PauseUi _pause;

    public void Execute()
    {
        _pause.ShowAudioVolume();
    }

    public void Initialization()
    {
        _pause = Object.FindObjectOfType<PauseUi>();
        UiInterface.PauseUi.StartCondition();
    }

    public override void On()
    {
        base.On();
        UiInterface.PauseUi.Pause();
    }

    public override void Off()
    {
        base.Off();
        UiInterface.PauseUi.Pause();
    }
}