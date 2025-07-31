using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class DirectorAction : MonoBehaviour
{
    private PlayableDirector pd;
    public Camera targetCam;
    
    void Start()
    {
        pd = GetComponent<PlayableDirector>();
        pd.Play();
    }

    void Update()
    {
        if (pd.time > pd.duration)
        {
            // 메인 카메라가 타겟 카메라라면 씨네머신 브레인을 비활성화
            if (Camera.main == targetCam)
                targetCam.GetComponent<CinemachineBrain>().enabled = false;
        }
        
        // 씨네머신에 사용한 카메라 비활성화
        targetCam.gameObject.SetActive(false);
        // 디렉터 자신을 비활성화
        gameObject.SetActive(false);
    }
}
