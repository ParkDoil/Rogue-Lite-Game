using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField]
    private CharacterStatus _status;

    public float GetSpeed()
    {
        return _status.Speed;
    }

    public int GetDamage()
    {
        return _status.AttackDamage;
    }

    public float GetHP()
    {
        return _status.HP;
    }
}
