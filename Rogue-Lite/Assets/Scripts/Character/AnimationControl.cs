using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator _animator;
    private Movement _movement;

    private Vector2 _inputVec;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        _inputVec.x = _movement.VectorX;
        _inputVec.y = _movement.VectorY;
    }

    private void LateUpdate()
    {
        _animator.SetFloat("Speed", _inputVec.magnitude);
    }
}
