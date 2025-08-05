using System;
using UnityEngine;

public class StudyCallback : MonoBehaviour
{
    public Action bombAction;

    void OnEnable()
    {
        bombAction += () =>
        {
            BombExplosion();
            BombDamage();
            BombEffect();
        };
    }

    void BombExplosion()
    {
        Debug.Log("폭탄 실행");
    }

    void BombDamage()
    {
        Debug.Log("폭발 데미지 실행");
    }

    void BombEffect()
    {
        Debug.Log("폭발 이펙트 실행");
    }
}
