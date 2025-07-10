using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardBar : MonoBehaviour
{
    public enum BarType { Left, Center, Right}

    public BarType barType;

    public Stack<GameObject> barStack = new Stack<GameObject>();

    private void OnMouseDown()
    {
        if (!HanoiTower.isSelected) // 선택이 안 된 상태
        {
            HanoiTower.selectedDonut = PopDonut();
        }
        else // 선택된 상태일 때
        {
            if (HanoiTower.selectedDonut != null)
                PushDonut(HanoiTower.selectedDonut);
        }
    }

    public bool CheckDonut(GameObject donut)
    {
        HanoiTower.isSelected = false;
        HanoiTower.selectedDonut = null;
        
        if (barStack.Count == 0) // 막대기가 빈 경우
            return true;

        int pushNumber = donut.GetComponent<Donut>().donutNumber;
        int peekNumber = barStack.Peek().GetComponent<Donut>().donutNumber;

        if (pushNumber < peekNumber)
        {
            return true;
        }
        else
        {
            Debug.Log($"현재 넣으려는 도넛은 {pushNumber}이고, 해당 기둥 제일 위의 도넛은 {peekNumber}입니다.");
            return false;
        }
    }

    public void PushDonut(GameObject donut)
    {
        if (!CheckDonut(donut))
            return;
        
        donut.transform.position = transform.position + Vector3.up * 5f;
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
        barStack.Push(donut);
    }

    public GameObject PopDonut()
    {
        if (barStack.Count <= 0) 
            return null;
        
        HanoiTower.isSelected = true;
        HanoiTower.currBar = this;
        return barStack.Pop();
    }
}
