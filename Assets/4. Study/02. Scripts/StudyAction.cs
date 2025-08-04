using System;
using UnityEngine;

public class StudyAction : MonoBehaviour
{
    public delegate void MyDelegate();
    public MyDelegate myDelegate;

    // 위 두 줄을 함축
    public Action action;
    
    // 매개변수 있는 경우
    public Action<string> action2;
    public Action<int, float, bool, string> action3;

    private void Start()
    {
        action += () => Debug.Log("Action");
        action += () =>
        {
            Debug.Log("Action 1");
            Debug.Log("Action 2");
        };
        
        action?.Invoke();

        action2 += msg => Debug.Log(msg);
        action2?.Invoke("Hello Unity");
    }
}
