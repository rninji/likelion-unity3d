using UnityEngine;

public class LocalData : MonoBehaviour
{
    private int score;

    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            score++;
            
            PlayerPrefs.SetInt("Score", score);
        }
    }
}
