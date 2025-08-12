using System;
using Unity.Cinemachine;
using UnityEngine;

public class FieldEvent : MonoBehaviour
{
    [SerializeField] private CinemachineClearShot clearShot;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Farm.GameManager.Instance.SetCameraState(CameraState.Field);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Farm.GameManager.Instance.SetCameraState(CameraState.Outside);
        }
    }
}