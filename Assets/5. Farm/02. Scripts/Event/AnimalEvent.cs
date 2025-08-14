using System;
using Unity.Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalEvent : MonoBehaviour
{
    [SerializeField] private GameObject flag;
    private BoxCollider boxCollider;

    private float timer;
    private bool isTimer;

    public static Action failAction;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        failAction += SetRandomPosition;
    }

    void Update()
    {
        if (!isTimer) return;
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTimer = true;
            
            SetRandomPosition();
            Farm.GameManager.Instance.SetCameraState(CameraState.Animal);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTimer = false;
            Debug.Log($"{timer}초 걸렸습니다.");
            timer = 0f;
            
            SetFlag(Vector3.zero, false);
            Farm.GameManager.Instance.SetCameraState(CameraState.Outside);
        }
    }
    
    // 깃발 위치 지정
    void SetRandomPosition()
    {
        float randomX = Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);
        float randomY = Random.Range(boxCollider.bounds.min.z, boxCollider.bounds.max.z);

        var randomPos = new Vector3(randomX, 0, randomY);
        
        SetFlag(randomPos, true);
    }

    // 깃발 위치 및 상태 조정
    void SetFlag(Vector3 pos, bool isActive)
    {
        flag.transform.SetParent(transform);
        flag.transform.position = pos;
        flag.SetActive(isActive);
    }
}
