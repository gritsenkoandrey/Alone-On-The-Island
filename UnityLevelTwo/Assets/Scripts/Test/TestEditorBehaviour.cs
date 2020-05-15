using System.Threading;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class TestEditorBehaviour : MonoBehaviour
{
    public float Count = 42.0f;
    public int Step = 2;

    private void Start()
    {
#if UNITY_EDITOR
        for (var i = 0; i < Count; i++)
        {
            EditorUtility.DisplayProgressBar("Загрузка", $"проценты {i}", i / Count);
            Thread.Sleep(Step * 100);
        }
        EditorUtility.ClearProgressBar();
        var isPassed = EditorUtility.DisplayDialog("Вопрос", "А оно тебе нужно?", "Ага", "Нет");
        if (isPassed)
        {
            EditorApplication.isPlaying = true;
        }
#endif
    }
}