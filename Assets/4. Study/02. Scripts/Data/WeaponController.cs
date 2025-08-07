using UnityEngine;


public class WeaponController : MonoBehaviour
{
    public GameObject[] weaponObjs;
    public WeaponData[] weaponDatas;

    public string currWeaponName;
    public int currWeaponDmg;
    public int currWeaponRange;

    void Start()
    {
        foreach (WeaponData data in weaponDatas)
        {
            Debug.Log($"{data.weaponName} / {data.attackDamage} / {data.attackRange}");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Swapweapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Swapweapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Swapweapon(2);
        }
    }

    void Swapweapon(int index)
    {
        foreach (GameObject weapon in weaponObjs)
            weapon.SetActive(false);
        weaponObjs[index].SetActive(true);

        currWeaponName = weaponDatas[index].weaponName;
        currWeaponDmg = weaponDatas[index].attackDamage;
        currWeaponRange = weaponDatas[index].attackRange;
    }
}