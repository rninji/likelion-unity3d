using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Pool;

public class StudyObjectPool2 : StudyGenericSingleton<StudyObjectPool2>
{
    public ObjectPool<GameObject> objPool;
    public GameObject objPrefab;

    void Awake()
    {
        objPool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject); // CreateObject만 필수
    }

    GameObject CreateObject()
    {
        GameObject obj = Instantiate(objPrefab, transform);
        obj.SetActive(false);
        
        return obj;
    }

    void GetObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    void ReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = objPool.Get();
        }
    }
}
