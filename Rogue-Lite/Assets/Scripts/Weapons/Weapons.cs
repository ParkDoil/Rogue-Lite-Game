using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    // ��� ���Ⱑ �������� ������ �ִ� ����
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
