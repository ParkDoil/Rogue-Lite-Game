using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWeaponMgr : MonoBehaviour
{
    #region Spin Weapon Data
    [SerializeField]
    private int _prefabID;

    private float _fireSpeed;
    [Header("자동공격무기 Data")]
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
        if (Input.GetButtonDown("Jump"))
        {
            LevelUp();
        }
    }

    private void Init()
    {

    }
    public void LevelUp()
    {
        if (AutoWeaponLevel >= 10)
        {
            return;
        }

        ++AutoWeaponLevel;
        if (AutoWeaponLevel % 2 == 1)
        {
            ++_autoWeaponTargetCount;
        }
        else
        {
            _autoWeaponCooldown -= 0.1f;
        }
    }
}
