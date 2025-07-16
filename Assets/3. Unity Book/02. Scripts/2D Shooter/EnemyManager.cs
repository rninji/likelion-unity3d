using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float currentTime;

    private float minTime = 1f;
    private float maxTime = 5f;
    private float createTime;

    public GameObject enemyFactory;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            // 생성
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            
            // 타이머 초기화
            currentTime = 0;
        }
    }
}
