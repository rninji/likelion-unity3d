using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        transform.position = target.transform.position;
    }
}
