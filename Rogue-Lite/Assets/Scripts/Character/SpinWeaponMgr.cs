using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeaponMgr : MonoBehaviour
{
    #region Spin Weapon Data
    [SerializeField]
    private int _prefabID;

    private float _spinSpeed;
    [Header("회전공격무기 Data")]
    [SerializeField]
    private int _spinWeaponID;
    [SerializeField]
    private int _spinWeaponDamage;
    [SerializeField]
    private int _spinWeaponLevel;
    [SerializeField]
    private int _spinWeaponCount;
    #endregion

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        
    }

    private void Init()
    {
        switch (_spinWeaponID)
        {
            case 0:
                _spinSpeed = -150f;
                PositionSet();
                break;
            default:
                break;
        }

    }

    private void PositionSet()
    {
        for (int i = 0; i < _spinWeaponCount; ++i)
        {
            Transform spinWeapon = GameManager.instance.PoolManager.Get(_prefabID).transform;
            spinWeapon.parent = transform;
            spinWeapon.GetComponent<SpinWeapon>().SetWeaponData(_spinWeaponID, _spinWeaponDamage, _spinWeaponLevel, _spinWeaponCount);
        }
    }
}
