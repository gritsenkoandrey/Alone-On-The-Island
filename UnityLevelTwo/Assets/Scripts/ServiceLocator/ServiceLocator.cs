﻿using System;
using System.Collections.Generic;


public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> _serviceContainer = new Dictionary<Type, object>();

    public static void SetService<T> (T value) where T : class
    {
        var typeValue = value.GetType();
        if (!_serviceContainer.ContainsKey(typeValue))
        {
            _serviceContainer[typeValue] = value;
        }
    }

    public static T Resolve<T>()
    {
        return (T)_serviceContainer[typeof(T)];
    }
}