using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
    
}
