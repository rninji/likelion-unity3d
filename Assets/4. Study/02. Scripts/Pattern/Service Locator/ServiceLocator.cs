using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ServiceLocator : MonoBehaviour
{
    private Dictionary<Type, object> services = new Dictionary<Type, object>();

    public T GetService<T>() where T : class
    {
        if (services.TryGetValue(typeof(T), out var service))
        {
            return service as T;
        }

        return null;
    }

    public void RegisterService<T>(T service)
    {
        services[typeof(T)] = service;
    }

    public void UnregisterServie<T>()
    {
        services.Remove(typeof(T));
    }
}