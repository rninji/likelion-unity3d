using Unity.Cinemachine;
using UnityEngine;

public enum CameraState { Outside, Field, House }

namespace Farm
{
    public class GameManager : Singleton<GameManager>
    {
        public CameraState cameraState;
        [SerializeField] private CinemachineClearShot clearShot;

        public void SetCameraState(CameraState newState)
        {
            if (cameraState == newState) return;

            cameraState = newState;
            foreach (var childCamera in clearShot.ChildCameras)
            {
                childCamera.Priority = 1;
            }

            clearShot.ChildCameras[(int)newState].Priority = 10;
        }
    }
}
