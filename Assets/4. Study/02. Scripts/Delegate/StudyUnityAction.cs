using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StudyUnityAction : MonoBehaviour
{
    public UnityAction unityAction;
    public Button button;
    
    void Start()
    {
        unityAction += MethodA;
        unityAction += MethodA;
        unityAction += MethodA;
        
        button.onClick.AddListener(unityAction);
        
        button.onClick.AddListener(() =>
        {
            Debug.Log("Hello");
            MethodA();
        });
    }

    void MethodA()
    {
        Debug.Log("Method A");
    }
}
