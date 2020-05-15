using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Gun))]
//[CanEditMultipleObjects] // разрешает обращаться к множеству скриптов с названием Gum
public sealed class GunEditor : Editor
{
    private SerializedProperty _ammunitionProperty;
    private SerializedProperty _barrelOneProperty;
    private SerializedProperty _forceProperty;
    private SerializedProperty _rechargeTimeProperty;

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

        EditorGUILayout.Slider(_forceProperty, 0, 10000, new GUIContent("Damage"));
        if (!_forceProperty.hasMultipleDifferentValues)
        {
            ProgressBar(_forceProperty.floatValue / 10000.0f, "Damage");
        }

        EditorGUILayout.Slider(_rechargeTimeProperty, 0, 1, new GUIContent("Recharge Time"));
        if (!_rechargeTimeProperty.hasMultipleDifferentValues)
        {
            ProgressBar(_rechargeTimeProperty.floatValue / 1.0f, "Recharge Time");
        }

        // применить изменения SerializedProperty - всегда делают в конце OnInspectorGUI
        serializedObject.ApplyModifiedProperties();
    }

    private void ProgressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        //пробел после бара
        EditorGUILayout.Space();
    }
}