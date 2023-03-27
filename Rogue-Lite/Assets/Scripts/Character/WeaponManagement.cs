using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{

    private int _weaponID;
    private int _prefabID;
    private float _spinSpeed;

    private void Update()
    {
        
    }

    private void Init()
    {
        switch (_weaponID)
        {
            case 0:
                _spinSpeed = -150f;
                break;
            default:
                break;
        }

    }

    private void PositionSet()
    {
        
    }
}
