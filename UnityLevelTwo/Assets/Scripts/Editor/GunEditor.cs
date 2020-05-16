using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Gun))]
//[CanEditMultipleObjects] // разрешает обращаться к множеству скриптов с названием Gum
public sealed class GunEditor : Editor
{
    #region Fields

    private SerializedProperty _ammunitionProperty;
    private SerializedProperty _barrelOneProperty;
    private SerializedProperty _forceProperty;
    private SerializedProperty _rechargeTimeProperty;

    private float _minValue = 0;
    private float _maxDamageValue = 10000.0f;
    private float _maxRechargeValue = 5.0f;

    #endregion


    #region UnityMethods

    private void OnEnable()
    {
        _ammunitionProperty = serializedObject.FindProperty("Ammunition");
        _barrelOneProperty = serializedObject.FindProperty("_barrelOne");
        _forceProperty = serializedObject.FindProperty("_force");
        _rechargeTimeProperty = serializedObject.FindProperty("_rechargeTime");
    }

    public override void OnInspectorGUI()
    {
        //обновление SerializedProperty - всегда делают вначале OnInspectorGUI
        serializedObject.Update();

        EditorGUILayout.PropertyField(_ammunitionProperty, new GUIContent("Bullet"));

        EditorGUILayout.PropertyField(_barrelOneProperty, new GUIContent("Barrel"));

        EditorGUILayout.Slider(_forceProperty, _minValue, _maxDamageValue, new GUIContent("Damage"));
        if (!_forceProperty.hasMultipleDifferentValues)
        {
            ProgressBar(_forceProperty.floatValue / _maxDamageValue, "Damage");
        }

        EditorGUILayout.Slider(_rechargeTimeProperty, _minValue, _maxRechargeValue, new GUIContent("Recharge Time"));
        if (!_rechargeTimeProperty.hasMultipleDifferentValues)
        {
            ProgressBar(_rechargeTimeProperty.floatValue / _maxRechargeValue, "Recharge Time");
        }

        // применить изменения SerializedProperty - всегда делают в конце OnInspectorGUI
        serializedObject.ApplyModifiedProperties();
    }

    #endregion


    #region Methods

    private void ProgressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }

    #endregion
}