using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Android;

public class AgentController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    public Transform[] points;
    public int index;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(points[index].position);
        if (agent.remainingDistance <= 2f) // 목적지 거리값이 2 이하일 경우 도착 판정 후 다음 목적지로 변경
        {
            index++;
            if (index >= points.Length) index = 0; // 루프
        }
    }
}
