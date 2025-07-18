using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float moveSpeed = 100f;
    public bool isMove = true;
    void Update()
    {
        if (isMove)
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var closetPos = other.ClosestPoint(transform.position); // 닿은 위치 중 가장 가까운 점에 고정
        transform.position = closetPos;
        transform.SetParent(other.transform);
        isMove = false;
    }
}
