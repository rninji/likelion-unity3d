using System;
using UnityEngine;

public class ObserverListener : MonoBehaviour, IObserver
{
    public Subject subject; // 관측 대상

    private void OnEnable()
    {
        subject.AddObserver(this);
    }

    private void OnDisable()
    {
        subject.RemoveObserver(this);
    }

    public void Notify()
    {
        Debug.Log("알림");
    }
}
