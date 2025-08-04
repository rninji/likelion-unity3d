using System;
using UnityEngine;

public class ScriptManager : Singleton<ScriptManager>
{
    public static Action action;

    void Awake()
    {
        action += MethodA;
        action += MethodB;
    }
    
    public void MethodA(){}
    public void MethodB(){}
    
}
