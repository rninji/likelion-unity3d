using System;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int score = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            StudyEventBus.ScoreChanged(score);
        }
    }
}
