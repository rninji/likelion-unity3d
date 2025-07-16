using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;

    private int currentScore;
    private int bestScore;

    private void Start()
    {
        currentScoreUI.text = "현재 점수 : 0";
        bestScoreUI.text = "최고 점수 : " + PlayerPrefs.GetInt("BestScore");
    }

    public void SetScore(int value)
    {
        currentScore = value;
        currentScoreUI.text = "현재 점수 : " + currentScore;
        
        // 최고 점수 갱신
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = "최고 점수 : " + bestScore;
            
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

    public int GetScore()
    {
        return currentScore;
    }
}
