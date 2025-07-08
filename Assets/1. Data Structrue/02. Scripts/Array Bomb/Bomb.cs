using System;
using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
   private Rigidbody bombRb;
   private float bombTime = 4f;
   private float bombRange = 10f;
   [SerializeField] LayerMask layerMask;

   private void Awake()
   {
      bombRb = GetComponent<Rigidbody>();
   }

   IEnumerator Start()
   {
      yield return new WaitForSeconds(bombTime);

      BombForce();
   }

   void BombForce()
   {
      Collider[] colliders = Physics.OverlapSphere(transform.position, bombRange, layerMask);

      foreach (var collider in colliders)
      {
         Rigidbody rb = collider.GetComponent<Rigidbody>();
         
         // AddExplosionForce (폭발 파워, 폭발 위치, 폭발 범위, 폭발 높이
         rb.AddExplosionForce(500f, transform.position, bombRange, 1f);
      }
      
      Destroy(gameObject);
   }
}
