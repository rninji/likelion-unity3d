using System;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
    }
}
