using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyObjectPool : StudyGenericSingleton<StudyObjectPool>
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();
    public GameObject objPrefab;

    public int poolSize = 100;

    private void Start()
    {
        CreateObject();
    }

    public void CreateObject()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObj = Instantiate(objPrefab, transform);
            objQueue.Enqueue(newObj);
            newObj.SetActive(false);
        }
    }

    public void EnqueueObject(GameObject obj)
    {
        objQueue.Enqueue(obj);
        obj.SetActive(false);
    }

    public GameObject DequeueObject()
    {
        if (objQueue.Count < 10)
            CreateObject();
        
        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);

        return obj;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = DequeueObject();
            obj.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        }
    }
}
