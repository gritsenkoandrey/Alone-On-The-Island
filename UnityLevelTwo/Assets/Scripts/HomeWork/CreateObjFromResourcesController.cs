public sealed class CreateObjFromResourcesController : BaseController, IInitialization
{
    #region Fields

    private CreateObjFromResources _objFromResources;

    #endregion


    #region Methods

    public void Initialization()
    {
        _objFromResources = ServiceLocatorMonoBehaviour.GetService<CreateObjFromResources>();
        On();
    }

    public override void On()
    {
        if (IsActive)
        {
            return;
        }

        base.On();

        _objFromResources.CreateObject();
    }

    public override void Off()
    {
        if (!IsActive)
        {
            return;
        }

        base.Off();
    }

    #endregion
}