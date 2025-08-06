using System;
using UnityEngine;

public class StudyGenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get {
            if (instance == null)
            {
                instance = FindFirstObjectByType<T>();
                if (instance == null)
                {
                    GameObject newObj = new GameObject(typeof(T).ToString());
                    instance = newObj.AddComponent<T>();
                }
            }

            return instance;
        }
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
