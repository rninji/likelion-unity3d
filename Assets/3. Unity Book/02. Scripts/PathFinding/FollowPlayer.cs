using System;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
   private Transform player;
   private NavMeshAgent agent;

   void Start()
   {
      player = GameObject.Find("Player").transform;
      agent = GetComponent<NavMeshAgent>();
   }


   private void Update()
   {
      agent.SetDestination(player.position);
   }
}
