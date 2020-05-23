public sealed class CreateObjFromResourcesController : BaseController, IInitialization
{
    #region Fields

    private CreateObjFromResources _objFromResources;

    #endregion


    #region Methods

    public void Initialization()
    {
        _objFromResources = ServiceLocatorMonoBehaviour.GetService<CreateObjFromResources>();
        _objFromResources.CreateObject();
    }

    #endregion
}