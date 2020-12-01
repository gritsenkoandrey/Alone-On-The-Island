using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsyncOperationBehaviour : MonoBehaviour
{

}

public static class AsyncOperationExtension
{
    #region Fields

    static AsyncOperationBehaviour asyncOperationBehaviour = null;
    static List<Coroutine> allCoroutines = new List<Coroutine>();

    #endregion


    #region Methods

    public static Coroutine StartCoroutine(this IEnumerator iterator, Action finishCallback = null)
    {
        Initialize();

        Coroutine asyncCoroutine = asyncOperationBehaviour.StartCoroutine(RunTaskInner(iterator, finishCallback));
        if (asyncCoroutine != null)
        {
            allCoroutines.Add(asyncCoroutine);
        }

        return asyncCoroutine;
    }

    public static Coroutine StartCoroutine(this AsyncOperation task, Action finishCallback = null)
    {
        Initialize();

        Coroutine asyncCoroutine = asyncOperationBehaviour.StartCoroutine(RunTaskAsyncInner(task, finishCallback));
        if (asyncCoroutine != null)
        {
            allCoroutines.Add(asyncCoroutine);
        }

        return asyncCoroutine;
    }

    public static void StopCoroutine(this Coroutine coroutine)
    {
        if ((coroutine != null) && (asyncOperationBehaviour))
        {
            if (allCoroutines.Contains(coroutine))
            {
                allCoroutines.Remove(coroutine);
                asyncOperationBehaviour.StopCoroutine(coroutine);
            }
        }
    }

    private static void Initialize()
    {
        if (asyncOperationBehaviour == null)
        {
            GameObject g = new GameObject();
            UnityEngine.Object.DontDestroyOnLoad(g);
            g.name = "AsyncOperationExtensionCoroutine";
            g.hideFlags = HideFlags.HideAndDontSave;

            asyncOperationBehaviour = g.AddComponent<AsyncOperationBehaviour>();
        }
    }

    private static IEnumerator RunTaskInner(IEnumerator task, Action finishCallback = null)
    {
        while (task.MoveNext())
        {
            yield return null;
        }

        if (finishCallback != null)
        {
            finishCallback();
        }
    }

    private static IEnumerator RunTaskAsyncInner(AsyncOperation task, Action finishCallback = null)
    {
        while (!task.isDone)
        {
            yield return null;
        }

        if (finishCallback != null)
        {
            finishCallback();
        }
    }

    #endregion
}