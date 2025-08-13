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
            Farm.GameManager.Instance.ui.ActivateFieldUI(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Farm.GameManager.Instance.SetCameraState(CameraState.Outside);
            Farm.GameManager.Instance.ui.ActivateFieldUI(false);
        }
    }
}