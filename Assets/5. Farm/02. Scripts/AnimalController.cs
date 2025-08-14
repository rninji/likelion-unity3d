using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AnimalController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    [SerializeField] private float wanderRadius = 15f;

    private float minWaitTime = 1f;
    private float maxWaitTime = 5f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private IEnumerator Start()
    {
        while (true)
        {
            // 목적지 설정
            SetRandomDestination(); 
            anim.SetBool("IsWalk", true);
            
            // 목적지 도착할 때까지 대기
            yield return new WaitUntil(()=>!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance); 
            
            // 일정 시간 정지
            anim.SetBool("IsWalk", false);
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        }
    }

    void SetRandomDestination()
    {
        // 자신의 위치로부터 wanderRadius만큼의 구체 내부에서 랜덤한 좌표 생성
        var randomDir = Random.insideUnitSphere * wanderRadius;
        randomDir += transform.position;

        NavMeshHit hit;
        // 해당 위치가 이동 가능하다면 목적지로 설정
        if (NavMesh.SamplePosition(randomDir, out hit, wanderRadius, NavMesh.AllAreas))
            agent.SetDestination(hit.position);
    }
}
