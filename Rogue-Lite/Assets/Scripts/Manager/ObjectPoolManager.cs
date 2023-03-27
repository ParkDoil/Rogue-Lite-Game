using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabs;
    [SerializeField]
    private Queue<GameObject>[] _objectPools;

    private void Awake()
    {
        _objectPools = new Queue<GameObject>[_prefabs.Length];

        for (int i = 0; i < _objectPools.Length; ++i)
        {
            _objectPools[i] = new Queue<GameObject>();
        }
    }

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < _objectPools.Length; ++i)
        {
            for (int j = 0; j < 100; ++j)
            {
                GameObject gameObj = Instantiate(_prefabs[i]);
                gameObj.SetActive(false);
                _objectPools[i].Enqueue(gameObj);
            }
        }
    }

    public GameObject Get(int index)
    {
        GameObject _selectObject = null;

        _selectObject = _objectPools[index].Dequeue();
        _selectObject.SetActive(true);

        if(!_selectObject)
        {
            _selectObject = Instantiate(_prefabs[index]);
            _objectPools[index].Enqueue(_selectObject);
            Get(index);
        }

        return _selectObject;
    }
}
