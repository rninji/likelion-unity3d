using System.Collections.Generic;
using UnityEngine;
public partial class StudyPartial : MonoBehaviour
{
    public void MethodC()
    {
        Debug.Log("Method C");
    }
}
public class StudyParameter : MonoBehaviour
{
    int number = 1;
    private int number2;
    
    public GameObject player;
    public GameObject enemy;
    public GameObject item;
    
    public List<GameObject> objs = new List<GameObject>();

    void Start()
    {
        NormalParameter(number);
        Debug.Log(number); // 1
        ReferenceParameter(ref number);
        Debug.Log(number); // 10
        
        int result = OutParameter(out number2);
        Debug.Log(result); // 30
        Debug.Log(number2); // 40
        
        int[] intArray = new int[3] { 10, 20, 30 };
        ArrayParameter(intArray);
        ParamsParameter(10, 20, 30, 40);
        
        // objs.Add(player);
        // objs.Add(enemy);
        // objs.Add(item);
        
        GameObjectActivate2(false, player, item);
        
        StudyPartial studyPartial = new StudyPartial();
        studyPartial.MethodB();	
    }

    void NormalParameter(int num)
    {
        num = 10;
    }

    void ReferenceParameter(ref int num)
    {
        num = 20;
    }

    int OutParameter(out int num)
    {
        num = 40;
        return 30;
    }

    // Collection을 매개변수로 넣은 경우
    void ArrayParameter(int[] numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }

    // 인자를 직접 넣어서 사용 가능
    void ParamsParameter(params int[] numbers)
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }

    private void GameObjectActivate()
    {
        // player.SetActive(false);
        // enemy.SetActive(false);
        // item.SetActive(false);
        
        foreach (var o in objs)
        {
            o.SetActive(false);
        }
    }

    private void GameObjectActivate2(bool isActive, params GameObject[] objs)
    {
        foreach (var o in objs)
            o.SetActive(isActive);
    }
}
