using System;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Vector3 offsetPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.SetParent(other.transform);
            transform.localPosition = offsetPos;
            transform.localRotation = Quaternion.identity;
        }
    }
}