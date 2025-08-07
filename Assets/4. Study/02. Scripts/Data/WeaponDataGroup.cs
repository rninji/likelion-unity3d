using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataGroup", menuName = "Scriptable Objects/WeaponDataGroup")]
public class WeaponDataGroup : ScriptableObject
{
    public WData[] wDatas;
}

[Serializable]
public class WData
{
    public string name;
    public DamageSystem dmg;
    public int range;
    public DetailData detail;
}

[Serializable]
public class DetailData
{
    public int cost;
    public int upgradeLevel;
}

[Serializable]
public class DamageSystem
{
    public int minDamage;
    public int maxDamage;
    public int successPercent;
}

