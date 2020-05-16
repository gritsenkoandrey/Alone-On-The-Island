using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GunRPG))]
public sealed class GunRPGEditor : Editor
{
    #region Fields

    private SerializedProperty _ammunitionRpgProperty;
    private SerializedProperty _barrelOneProperty;
    private SerializedProperty _barrelTwoProperty;
    private SerializedProperty _barrelThreeProperty;
    private SerializedProperty _forceProperty;
    private SerializedProperty _rechargeTimeProperty;

    private float _minValue = 0;
    private float _maxDamageValue = 10000.0f;
    private float _maxRechargeValue = 10.0f;

    #endregion


    #region UnityMethods

    private void OnEnable()
    {
        _ammunitionRpgProperty = serializedObject.FindProperty("AmmunitionRPG");
        _barrelOneProperty = serializedObject.FindProperty("_barrelOne");
        _barrelTwoProperty = serializedObject.FindProperty("_barrelTwo");
        _barrelThreeProperty = serializedObject.FindProperty("_barrelThree");
        _forceProperty = serializedObject.FindProperty("_force");
        _rechargeTimeProperty = serializedObject.FindProperty("_rechargeTime");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_ammunitionRpgProperty, new GUIContent("RPG"));

        EditorGUILayout.PropertyField(_barrelOneProperty, new GUIContent("Barrel One"));
        EditorGUILayout.PropertyField(_barrelTwoProperty, new GUIContent("Barrel Two"));
        EditorGUILayout.PropertyField(_barrelThreeProperty, new GUIContent("Barrel Three"));

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