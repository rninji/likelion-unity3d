using UnityEngine;

public class StudySingleton : MonoBehaviour
{
    public static StudySingleton instance;

    public int number;

    void Start()
    {
        instance = this;
    }
}
