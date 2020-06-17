using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(CreateInterface))]
public class CreateInterfaceEditor : Editor
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

        _isPressButtonMainMenu = GUILayout.Button("Создать главное меню", EditorStyles.miniButton);
        _isPressButtonMenuPause = GUILayout.Button("Создать меню паузы", EditorStyles.miniButton);

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