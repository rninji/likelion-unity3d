using System;
using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    StudyUnityEvent studyUnityEvent;

    private void Start()
    {
        ScriptManager.action?.Invoke();
    }
}
