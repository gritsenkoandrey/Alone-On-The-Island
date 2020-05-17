using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(TestBehaviour))]
public sealed class TestBehaviourEditor : Editor
{
    #region Fields

    private TestBehaviour _testTarget;
    private bool _isPressButtonOk;

    #endregion


    #region Methods

    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();
        //target - это экземпляр класса на который будет ссылаться TestBehaviour
        _testTarget = (TestBehaviour)target;
        _testTarget.count = EditorGUILayout.IntSlider(_testTarget.count, 10, 50);
        _testTarget.offset = EditorGUILayout.IntSlider(_testTarget.offset, 1, 5);

        _testTarget.obj = EditorGUILayout.ObjectField("Объект для добавления",
            _testTarget.obj, typeof(GameObject), false) as GameObject;

        var isPressButton = GUILayout.Button("Создание объекта по кнопке", EditorStyles.miniButtonLeft);

        _isPressButtonOk = GUILayout.Toggle(_isPressButtonOk, "Ok");

        if (isPressButton)
        {
            _testTarget.CreateObj();
            _isPressButtonOk = true;
        }

        if (_isPressButtonOk)
        {
            _testTarget.Test = EditorGUILayout.Slider(_testTarget.Test, 10, 50);
            EditorGUILayout.HelpBox("Вы нажали на кнопку", MessageType.Warning);

            var isPressAddButton = GUILayout.Button("Add Component", EditorStyles.miniButtonLeft);

            if (isPressAddButton)
            {
                _testTarget.AddComponent();
            }

            if (GUILayout.Button("Remove Component", EditorStyles.miniButtonLeft))
            {
                _testTarget.RemoveComponent();
            }
        }
    }

    #endregion
}