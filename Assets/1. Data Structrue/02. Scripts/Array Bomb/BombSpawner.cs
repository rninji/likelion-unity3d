using System.Collections;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;

    public int rangeX = 5;
    public int rangeZ = 5;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            
            RespawnBomb();
        }
    }

    public void RespawnBomb()
    {
        float ranX = Random.Range(-rangeX, rangeX);
        float ranZ = Random.Range(-rangeZ, rangeZ);

        Vector3 ranPos = new Vector3(ranX, 10f, ranZ);

        Instantiate(bombPrefab, ranPos, Quaternion.identity);
    }
}
