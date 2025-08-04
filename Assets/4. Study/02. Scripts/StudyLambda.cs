using System;
using UnityEditor;
using UnityEngine;

public class StudyLambda : MonoBehaviour
{
    public delegate void MyDelegate();
    public MyDelegate myDelegate;
    
    public delegate void MyDelegate2(string s);
    public MyDelegate2 myDelegate2;

    private void Start()
    {
        // 한줄
        myDelegate += () => OnLog();

        // 여러줄
        myDelegate += () =>
        {
            OnLog();
            transform.position = Vector3.zero;
        };
        
        // 매개변수 있는 경우
        myDelegate2 += (n) =>
        {
            OnLog(n);
            Debug.Log(n);
        };
        
        myDelegate?.Invoke();
        myDelegate2?.Invoke("Hello MyDelegate2");
    }

    void OnLog()
    {
        Debug.Log("Hello Unity");
    }

    void OnLog(string msg)
    {
        Debug.Log(msg);
    }
}
