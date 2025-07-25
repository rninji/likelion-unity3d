using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingNextScene : MonoBehaviour
{
    public int sceneNumber = 2;
    public Slider loadingSlider;
    public TextMeshProUGUI loadingText;

    private void Start()
    {
        StartCoroutine(TransitionNextScene(sceneNumber));
    }

    IEnumerator TransitionNextScene(int num)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(num);

        ao.allowSceneActivation = false; // 로드가 완료되어도 표시 X

        while (!ao.isDone)
        {
            loadingSlider.value = ao.progress; // ao의 진행률을 슬라이더에 반영
            loadingText.text = $"{ao.progress * 100f}%";

            if (ao.progress >= 0.9f) // 씬 로드 진행률이 90% 이상이 되면
                ao.allowSceneActivation = true; // 로드된 씬을 화면에 표시

            yield return null;
        }
    }
}
