using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    // 모든 무기가 공통으로 가지고 있는 변수
    public int ID { get; private set; }
    public int Damage { get; private set; }
    public int WeaponLevel { get; private set; }

    public void SetWeaponData(int id, int damage, int weaponLevel)
    {
        ID = id;
        Damage = damage;
        WeaponLevel = weaponLevel;
    }
}
