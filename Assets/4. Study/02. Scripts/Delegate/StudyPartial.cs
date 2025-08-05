using UnityEngine;

public partial class StudyPartial : MonoBehaviour
{
    int number;
    void Start()
    {
        MethodA();
        MethodB();
    }

    public void MethodA()
    {
        Debug.Log("Method A");
    }
}


public partial class StudyPartial : MonoBehaviour
{
    // int number;
    public void MethodB()
    {
        Debug.Log("Method B");
    }
}