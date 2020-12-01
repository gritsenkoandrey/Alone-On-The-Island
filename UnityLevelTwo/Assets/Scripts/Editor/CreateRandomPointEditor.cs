using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;


[CustomEditor(typeof(CreateRandomPoint))]
public sealed class CreateRandomPointEditor : Editor
{
    #region Fields

    private int _minCount = 0;
    private int _maxCount = 100;
    private float _bar = 0.01f;
    private CreateRandomPoint _targetCreateRandomPoint;

    #endregion


    #region UnityMethods

    public override void OnInspectorGUI()
    {
        _targetCreateRandomPoint = (CreateRandomPoint)target;

        _targetCreateRandomPoint.count = EditorGUILayout.IntSlider(_targetCreateRandomPoint.count, _minCount, _maxCount);
        ProgressBar(_targetCreateRandomPoint.count * _bar, "Count Object");

        _targetCreateRandomPoint.offset = EditorGUILayout.Slider(_targetCreateRandomPoint.offset, _minCount, _maxCount);
        ProgressBar(_targetCreateRandomPoint.offset * _bar, "Offset Height");

        _targetCreateRandomPoint.gameObj = EditorGUILayout.ObjectField("Object",
            _targetCreateRandomPoint.gameObj, typeof(GameObject), false) as GameObject;

        _targetCreateRandomPoint.name = EditorGUILayout.TextField("Name Object", _targetCreateRandomPoint.name);

        var isPressButton = GUILayout.Button("Create Object", EditorStyles.miniButtonLeft);

        if (isPressButton)
        {
            _targetCreateRandomPoint.CreateObject();
            SetObjectDirty(_targetCreateRandomPoint.gameObject);
        }
    }

    #endregion


    #region Methods

    private void ProgressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(20, 20, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }

    public void SetObjectDirty(GameObject gameObj)
    {
        if (!Application.isPlaying)
        {
            EditorUtility.SetDirty(gameObj);
            EditorSceneManager.MarkSceneDirty(gameObj.scene);
        }
    }

    #endregion
}