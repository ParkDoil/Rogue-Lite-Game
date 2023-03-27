using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : Weapons
{
    public int WeaponCount { get; private set; }

    public void SetWeaponData(int id, int damage, int weaponLevel, int weaponCount)
    {
        base.SetWeaponData(id, damage, weaponLevel);
        WeaponCount = weaponCount;
    }
}
