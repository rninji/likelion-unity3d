using System;
using UnityEngine;

public class StudyFunc3 : MonoBehaviour
{
    public int hp = 100;
    public Func<int> GetHp;
    public Func<float, float> GetRemainHp;
    public Func<string> GetAction;

    void Start()
    {
        GetHp = () => hp;
        GetRemainHp = (dmg) => hp - dmg;
        GetAction = () =>
        {
            if (GetHp() > 50)
                return "공격";
            else if (GetHp() > 0)
                return "도망";
            else 
                return "죽음";
        };
    }
}
