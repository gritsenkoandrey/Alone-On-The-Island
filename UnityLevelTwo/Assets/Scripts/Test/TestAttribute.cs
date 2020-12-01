using System;
using UnityEngine;


// RequireComponent связывает TestAttribute и Renderer (Mesh Rendere в инспекторе не получится исключить)
// ExecuteInEditMode позволяет выполнять методы юнити в незапущенном проекте
// DisallowMultipleComponent означает что на один объект нельзя накинуть 2 одинаковых скрипта
[RequireComponent(typeof(Renderer)), ExecuteInEditMode, DisallowMultipleComponent]
public sealed class TestAttribute : MonoBehaviour
{
    [HideInInspector] public float TestPublic;
    [SerializeField] private float _testPrivate = 7;
    private float _testPrivateTwo;
    public SerializableGameObject SerializableGameObject;

    private const int _min = 0;
    private const int _max = 100;
    [Header("Test variables")]
    [ContextMenuItem("Randomize Number", nameof(Randomize))]
    [Range(_min, _max)]
    public int SecondTest;

    [Space(60)]
    [SerializeField, Multiline(5)] private string _testMultiline;
    [Space(60)]
    [SerializeField, TextArea(5, 5), Tooltip("Tooltip text")] private string _testTextArea;


    private void Update()
    {
        GetComponent<Renderer>().sharedMaterial.color = UnityEngine.Random.ColorHSV();
    }

    private void OnGUI()
    {
        GUILayout.Button("Click Me");
    }


    private void Randomize()
    {
        SecondTest = UnityEngine.Random.Range(_min, _max);
    }

    [Obsolete("Устарело. Используй что-то другое")]
    private void TestObsolete()
    {
    }

}