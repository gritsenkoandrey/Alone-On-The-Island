using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Object = UnityEngine.Object;


public static class ServiceLocatorMonoBehaviour
{
    #region Fields

    private static Dictionary<Type, object> _serviceContainer = new Dictionary<Type, object>();
    //private static Dictionary<object, object> _serviceContainer = null;

    #endregion


    #region Methods

    public static T GetService<T>(bool createObjectIfNotFound = true) where T : Object
    {
        //if (_serviceContainer == null)
        //{
        //    _serviceContainer = new Dictionary<object, object>();
        //}

        if (!_serviceContainer.ContainsKey(typeof(T)))
        {
            return FindService<T>(createObjectIfNotFound);
        }

        var service = (T)_serviceContainer[typeof(T)];
        if (service != null)
        {
            return service;
        }

        _serviceContainer.Remove(typeof(T));
        return FindService<T>(createObjectIfNotFound);
    }

    private static T FindService<T>(bool createObjectIfNotFound = true) where T : Object
    {
        T type = Object.FindObjectOfType<T>();
        if (type != null)
        {
            _serviceContainer.Add(typeof(T), type);
        }
        else if (createObjectIfNotFound)
        {
            var go = new GameObject(typeof(T).Name, typeof(T));
            _serviceContainer.Add(typeof(T), go.GetComponent<T>());
        }
        return (T)_serviceContainer[typeof(T)];
    }

    public static void Cleanup()
    {
        var objects = _serviceContainer.Values.ToList();
        foreach (Object t in objects)
        {
            Object.Destroy(t);
        }

        _serviceContainer.Clear();
    }

    #endregion
}