using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    private object[] array = new object[3];

    void Add(object o)
    {
        var temp = new object[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            temp[i] = array[i];
        }

        array = temp;
        array[array.Length - 1] = 0;
    }

    List<int> list1 = new List<int>();
    List<int> list2 = new List<int>() { 1, 2, 3, 4, 5};
    List<int> list3;
    
    void Start()
    {
        list1.Add(10);
        list2.Add(20);
        list3.Add(30);

        for (int i = 0; i < 10; i++)
        {
            list1.Add(i);
        }

        list1.Insert(5, 100); // 5번 인덱스에 100이라는 값 끼워넣음

        list1.Remove(5); // 값 5를 제거
        list1.RemoveAt(5); // 5번째 인덱스 값을 제거
        
        list1.RemoveRange(1, 3); // 인덱스 1번부터 3개 제거
        
        list1.Clear(); // 데이터 모두 제거

        list1.RemoveAll(x => x > 5); // 조건에 맞는 값을 전부 삭제
    }
}
