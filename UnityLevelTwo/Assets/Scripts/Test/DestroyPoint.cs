using System;
using UnityEngine;


public sealed class DestroyPoint : MonoBehaviour
{
    #region Fields
    // паттерн null object
    public event Action<GameObject> OnFinishChange = delegate (GameObject o) { };

    #endregion


    #region UnityMethods

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bot>())
        {
            OnFinishChange.Invoke(gameObject);
        }
    }

    #endregion
}