using Unity.Cinemachine;
using UnityEngine;

public class AnimalEvent : MonoBehaviour
{
    [SerializeField] private CinemachineClearShot clearShot;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Farm.GameManager.Instance.SetCameraState(CameraState.Animal);
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
