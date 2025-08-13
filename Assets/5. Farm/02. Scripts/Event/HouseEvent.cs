using System;
using Unity.Cinemachine;
using UnityEngine;

public class HouseEvent : MonoBehaviour
{
    [SerializeField] private CinemachineClearShot clearShot;
    [SerializeField] private GameObject houseTop; // 지붕 오브젝트
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Farm.GameManager.Instance.SetCameraState(CameraState.Field);
            houseTop.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Farm.GameManager.Instance.SetCameraState(CameraState.Outside);
            houseTop.SetActive(true);
        }
    }
}
