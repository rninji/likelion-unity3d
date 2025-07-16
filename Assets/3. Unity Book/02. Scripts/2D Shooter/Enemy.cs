using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 3f;

    public GameObject explosionFactory;
    
    void Start()
    {
        int ranvValue = Random.Range(0, 10);

        if (ranvValue < 3) // 30%
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject smObj = GameObject.Find("ScoreManager");
        ScoreManager sm = smObj.GetComponent<ScoreManager>();
        sm.SetScore(sm.GetScore() + 1);
        
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
