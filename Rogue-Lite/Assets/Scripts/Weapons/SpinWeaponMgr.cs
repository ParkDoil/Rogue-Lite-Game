using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeaponMgr : MonoBehaviour
{
    #region Spin Weapon Data
    [SerializeField]
    private int _prefabID;
    private int _count;

    private float _spinSpeed;
    [Header("회전공격무기 Data")]
    [SerializeField]
    private int _spinWeaponID;
    [SerializeField]
    private int _spinWeaponDamage;
    [field: SerializeField]
    public int SpinWeaponLevel { get; private set; }
    [SerializeField]
    private int _spinWeaponCount;
    [field:SerializeField]
    public int SpinWeaponTotalDamage { get; private set; }
    #endregion

    private Status _status;

    private void Awake()
    {
        _status = GetComponentInParent<Status>();
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        transform.Rotate(Vector3.back * _spinSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            LevelUp();
        }
    }

    private void Init()
    {
        _spinSpeed = 150f;
        PositionSet();
        TotalDamageSet();
    }

    public void LevelUp()
    {
        if(SpinWeaponLevel >= 10)
        {
            return;
        }

        ++SpinWeaponLevel;
        if (SpinWeaponLevel % 2 == 1)
        {
            ++_spinWeaponCount;
            PositionSet();
        }
        else
        {
            if(SpinWeaponLevel != 10)
            {
                ++_spinWeaponDamage;
            }
            else
            {
                ++_spinWeaponDamage;
                _spinWeaponDamage *= 2;
            }
            TotalDamageSet();
        }
    }

    private void PositionSet()
    {
        for (int i = 0; i < _spinWeaponCount; ++i)
        {
            if(_spinWeaponCount > 5)
            {
                return;
            }

            Transform spinWeapon;

            if (i < transform.childCount)
            {
                spinWeapon = transform.GetChild(i);
            }
            else
            {
                spinWeapon = GameManager.instance.PoolManager.Get(_prefabID).transform;
                spinWeapon.parent = transform;
            }

            spinWeapon.localPosition = Vector3.zero;
            spinWeapon.localRotation = Quaternion.identity;

            Vector3 rotateVec = Vector3.forward * 360 * i / _spinWeaponCount;
            spinWeapon.Rotate(rotateVec);
            spinWeapon.Translate(spinWeapon.up * 1.0f, Space.World);
        }
    }

    private void TotalDamageSet()
    {
        SpinWeaponTotalDamage = _spinWeaponDamage + _status.GetDamage();
    }
}
