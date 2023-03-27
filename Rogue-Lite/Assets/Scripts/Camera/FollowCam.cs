using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowCam : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachine;
    private GameObject _targetPlayer;

    private void Awake()
    {
        _cinemachine = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if(_targetPlayer == GameManager.instance._player)
        {
            return;
        }

        _targetPlayer = GameManager.instance._player;
        _cinemachine.Follow = _targetPlayer.transform;
    }
}
