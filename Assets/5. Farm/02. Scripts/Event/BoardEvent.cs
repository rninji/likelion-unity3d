using UnityEngine;

public class BoardEvent : MonoBehaviour
{
    [SerializeField] private GameObject boardUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Farm.GameManager.Instance.SetCameraState(CameraState.Board);
            boardUI.SetActive(true);
            Single_BoardController.StartAction?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Farm.GameManager.Instance.SetCameraState(CameraState.House);
            boardUI.SetActive(false);
        }
    }
}
