public sealed class PauseController : BaseController, IInitialization
{
    public void Initialization()
    {
        UiInterface.PauseUi.StartCondition();
    }

    public override void On()
    {
        base.On();
        UiInterface.PauseUi.Pause();
    }

    //public override void Off()
    //{
    //    base.Off();
    //}
}