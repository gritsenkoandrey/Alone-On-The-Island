using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Gun))]
//[CanEditMultipleObjects] // разрешает обращаться к множеству скриптов с названием Gum
public sealed class GunEditor : Editor
{
    #region Fields

    private SerializedProperty _ammunitionProperty;
    private SerializedProperty _barrelOneProperty;
    private SerializedProperty _particleSystem;
    private SerializedProperty _forceProperty;
    private SerializedProperty _rechargeTimeProperty;
    private SerializedProperty _audioClips;

    private float _minValue = 0;
    private float _maxForceValue = 10000.0f;
    private float _maxRechargeValue = 5.0f;

    #endregion


    #region UnityMethods

    private void OnEnable()
    {
        _ammunitionProperty = serializedObject.FindProperty("Ammunition");
        _barrelOneProperty = serializedObject.FindProperty("_barrelOne");
        _particleSystem = serializedObject.FindProperty("_particleSystem");
        _forceProperty = serializedObject.FindProperty("_force");
        _rechargeTimeProperty = serializedObject.FindProperty("_rechargeTime");
        _audioClips = serializedObject.FindProperty("_audioClips");
    }

    public override void OnInspectorGUI()
    {
        //обновление SerializedProperty - всегда делают вначале OnInspectorGUI
        serializedObject.Update();

        EditorGUILayout.PropertyField(_ammunitionProperty, new GUIContent("Bullet"));

        EditorGUILayout.PropertyField(_barrelOneProperty, new GUIContent("Barrel"));

        EditorGUILayout.PropertyField(_particleSystem, new GUIContent("Particle"));

        EditorGUILayout.Slider(_forceProperty, _minValue, _maxForceValue, new GUIContent("Force"));
        if (!_forceProperty.hasMultipleDifferentValues)
        {
            ProgressBar(_forceProperty.floatValue / _maxForceValue, "Force");
        }

        EditorGUILayout.Slider(_rechargeTimeProperty, _minValue, _maxRechargeValue, new GUIContent("Recharge Time"));
        if (!_rechargeTimeProperty.hasMultipleDifferentValues)
        {
            ProgressBar(_rechargeTimeProperty.floatValue / _maxRechargeValue, "Recharge Time");
        }

        EditorGUILayout.PropertyField(_audioClips, new GUIContent("AudioClips"));

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