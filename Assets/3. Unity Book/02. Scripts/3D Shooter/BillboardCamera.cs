using UnityEngine;

public class BillboardCamera : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
