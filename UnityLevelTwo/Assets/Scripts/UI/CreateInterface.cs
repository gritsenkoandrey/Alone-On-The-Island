using UnityEngine;


public class CreateInterface : MonoBehaviour
{
#if UNITY_EDITOR
    #region Editor

    public void CreateMainMenu()
    {
        gameObject.AddComponent<MainMenu>();
        gameObject.AddComponent<OptionsMenu>();
    }

    public void CreateMenuPause()
    {
        CreateComponent();
        Clear();
    }

    private void Clear()
    {
        DestroyImmediate(this);
    }

    private void CreateComponent()
    {
        gameObject.AddComponent<Interface>();
        gameObject.AddComponent<InterfaceResources>();
    }

    #endregion
#endif
}