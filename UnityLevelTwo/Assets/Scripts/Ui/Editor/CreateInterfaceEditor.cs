using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(CreateInterface))]
public sealed class CreateInterfaceEditor : Editor
{
    #region Fields

    private static CreateInterface _interface;
    private static bool _isPressButtonMainMenu;
    private static bool _isPressButtonMenuPause;

    #endregion

    #region Methods

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        DrawDefaultInspector();
        _interface = (CreateInterface)target;

        if (EditorApplication.isPlaying)
        {
            return;
        }
        _isPressButtonMainMenu = GUILayout.Button("Создать Главное Меню", EditorStyles.miniButton);
        _isPressButtonMenuPause = GUILayout.Button("Создать Меню Паузы", EditorStyles.miniButton);

        if (_isPressButtonMainMenu)
        {
            _interface.CreateMainMenu();
        }
        if (_isPressButtonMenuPause)
        {
            _interface.CreateMenuPause();
        }
    }

    #endregion
}