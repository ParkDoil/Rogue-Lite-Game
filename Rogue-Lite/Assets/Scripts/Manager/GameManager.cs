using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [field: SerializeField]
    public ObjectPoolManager PoolManager { get; private set; }

    public GameObject _player { get; private set; }

    private void Awake()
    {
        instance = this;
    }
    
    public void GetPlayerObject(GameObject _charactor)
    {
        _player = _charactor;
    }
}
