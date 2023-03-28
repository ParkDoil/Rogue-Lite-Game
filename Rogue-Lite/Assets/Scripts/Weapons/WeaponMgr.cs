using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMgr : MonoBehaviour
{
    private int _weaponID;
    private float _elapsedTime;

    private Movement _player;

    #region Spin Weapon Data
    [Header("회전공격무기 Data")]
    [SerializeField]
    private int _spinWeaponPrefabID;
    private float _spinSpeed;
    [SerializeField]
    private int _spinWeaponID;
    [SerializeField]
    private int _spinWeaponDamage;
    [field: SerializeField]
    public int SpinWeaponLevel { get; private set; }
    [SerializeField]
    private int _spinWeaponCount;
    public int SpinWeaponTotalDamage { get; private set; }
    #endregion

    #region Spin Weapon Data
    [Header("자동공격무기 Data")]
    [SerializeField]
    private int _autoWeaponPrefabID;
    private float _fireSpeed;
    [SerializeField]
    private int _autoWeaponID;
    [SerializeField]
    private int _autoWeaponDamage;
    [field: SerializeField]
    public int AutoWeaponLevel { get; private set; }
    [SerializeField]
    private float _autoWeaponCooldown;
    [SerializeField]
    private int _autoWeaponTargetCount;
    public int AutoWeaponTotalDamage { get; private set; }
    #endregion

    private Status _status;

    private void Awake()
    {
        _status = GetComponentInParent<Status>();
        _player = GetComponentInParent<Movement>();
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        switch(_weaponID)
        {
            case 0:
                transform.Rotate(Vector3.back * _spinSpeed * Time.deltaTime);
                break;
            default:
                _elapsedTime += Time.deltaTime;

                if(_elapsedTime > _autoWeaponCooldown)
                {
                    _elapsedTime = 0f;
                    AutoFire();
                }
                break;
        }

        if (Input.GetButtonDown("Jump"))
        {

        }
    }

    private void Init()
    {
        _spinSpeed = 150f;
        PositionSet();
        TotalDamageSet();
    }

    // 무기 레벨업 구현부
    #region LevelUP
    public void SpinWeaponLevelUp()
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

    public void AutoWeaponLevelUp()
    {
        if (AutoWeaponLevel >= 10)
        {
            return;
        }

        ++AutoWeaponLevel;
        if (AutoWeaponLevel % 2 == 1)
        {
            _autoWeaponCooldown -= 0.15f;
        }
        else
        {
            if (SpinWeaponLevel != 10)
            {
                ++_autoWeaponDamage;
            }
            TotalDamageSet();
        }
    }
    #endregion

    // 회전무기 위치 배치
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
                spinWeapon = GameManager.instance.PoolManager.Get(_spinWeaponPrefabID).transform;
                spinWeapon.parent = transform;
            }

            spinWeapon.localPosition = Vector3.zero;
            spinWeapon.localRotation = Quaternion.identity;

            Vector3 rotateVec = Vector3.forward * 360 * i / _spinWeaponCount;
            spinWeapon.Rotate(rotateVec);
            spinWeapon.Translate(spinWeapon.up * 1.0f, Space.World);
        }
    }

    // 최종 데미지 세팅
    private void TotalDamageSet()
    {
        SpinWeaponTotalDamage = _spinWeaponDamage + _status.GetDamage();
        AutoWeaponTotalDamage = _autoWeaponDamage + _status.GetDamage();
    }

    // 자동 공격 무기 발사 구현부
    private void AutoFire()
    {
        if(!_player.Scanner.NearTarget)
        {
            return;
        }

        Transform autoBullet = GameManager.instance.PoolManager.Get(_autoWeaponPrefabID).transform;
        autoBullet.position = transform.position;
    }
}
