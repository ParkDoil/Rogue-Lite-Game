using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttackWeapon : Weapons
{
    public float WeaponDelay { get; private set; }
    public int TargetCount { get; private set; }

    public void SetWeaponData(int id, int damage, int weaponLevel, float weaponDelay, int targetCount)
    {
        base.SetWeaponData(id, damage, weaponLevel);
        WeaponDelay = weaponDelay;
        TargetCount = targetCount;
    }
}
