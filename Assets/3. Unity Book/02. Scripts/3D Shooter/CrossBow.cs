using System;
using System.Collections;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPos;

    private Ray ray = new Ray();
    private RaycastHit hit;

    private bool isShoot;

    void Update()
    {
        Ray ray = new Ray(shootPos.position, shootPos.forward);
        RaycastHit hit;

        bool isTargeting = Physics.Raycast(ray, out hit);
        
        // Debug.DrawRay(shootPos.position, shootPos.forward, Color.green);
        
        if (!isShoot && isTargeting)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    IEnumerator ShootRoutine()
    {
        isShoot = true;
        
        GameObject arrow = Instantiate(arrowPrefab);
            
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        arrow.transform.SetPositionAndRotation(shootPos.position, rot);
        yield return new WaitForSeconds(3f);
        isShoot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootPos.position, shootPos.forward * 100f);
    }
}
