using System.Collections;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }

    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs;
    public BoardBar[] bars;
    public static BoardBar currBar;

    public static GameObject selectedDonut;
    public static bool isSelected;

    IEnumerator CreateDonuts()
    {
        for (int i = (int)hanoiLevel -1; i >= 0; i--)
        {
            GameObject donut = Instantiate(donutPrefabs[i]);
            donut.transform.position = new Vector3(-5f, 5f, 0);

            bars[0].PushDonut(donut);
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currBar.barStack.Push(selectedDonut);
            
            isSelected = false;
            selectedDonut = null;
        }
    }

    void Start()
    {
        StartCoroutine(CreateDonuts()); // 도넛 생성
        HanoiTowerFunc((int)hanoiLevel, 0, 1, 2); // 해결 재귀 함수
    }

    public void HanoiTowerFunc(int n, int from, int temp, int to)
    {
        if (n == 0) return;
        
        if (n == 1)
            Debug.Log($"{n}번 원반을 {from}에서 {to}로 이동");
        else
        {
            HanoiTowerFunc(n-1, from, to, temp);
            Debug.Log($"{n}번 원반을 {from}에서 {to}로 이동");
            HanoiTowerFunc(n-1, from, to, temp);
        }
    }
}
