using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabs;
    private List<GameObject>[] _objectPools;

    private void Awake()
    {
        _objectPools = new List<GameObject>[_prefabs.Length];

        for (int i = 0; i < _objectPools.Length; ++i)
        {
            _objectPools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject _selectObject = null;

        foreach (GameObject item in _objectPools[index])
        {
            if(!item.activeSelf)
            {
                _selectObject = item;
                _selectObject.SetActive(true);
                break;
            }
        }

        if(!_selectObject)
        {
            _selectObject = Instantiate(_prefabs[index], transform);
            _objectPools[index].Add(_selectObject);
        }

        return _selectObject;
    }
}
