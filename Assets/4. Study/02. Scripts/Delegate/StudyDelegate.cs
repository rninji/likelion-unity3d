using UnityEngine;

public class StudyDelegate : MonoBehaviour
{
    public delegate void MyDelegate(int n=0);

    public MyDelegate myDelegate;

    void Start()
    {
        myDelegate += MethodA;
        myDelegate += MethodB;
        myDelegate += MethodC;
        myDelegate?.Invoke();
    }
    void MethodA(int a)
    {
        Debug.Log("Method A"+a);
    }

    void MethodB(int b)
    {
        Debug.Log("Method B"+b);
    }

    void MethodC(int c)
    {
        Debug.Log("Method C"+c);
    }
}
