using System.Threading;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class TestEditorBehaviour : MonoBehaviour
{
    #region Fields

    public float Count = 100.0f;
    public int Step = 10;

    #endregion

    
    #region UnityMethods

    private void Start()
    {
    #if UNITY_EDITOR
        for (var i = 0; i < Count; i++)
        {
            EditorUtility.DisplayProgressBar("Загрузка", $"проценты {i}", i / Count);
            Thread.Sleep(Step * 100);
        }
        EditorUtility.ClearProgressBar();
        var isPassed = EditorUtility.DisplayDialog("Продолжить", "Точно продолжить?", "Да", "Нет");
        if (isPassed)
        {
            EditorApplication.isPlaying = true;
        }
    #endif
    }
    #endregion
}