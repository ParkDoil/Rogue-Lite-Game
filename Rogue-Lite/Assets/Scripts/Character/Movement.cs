using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private CharacterInput _input;
    private Vector2 MoveVec;
    private Vector2 NomalVec;
    private Vector2 MovePosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<CharacterInput>();
    }

    private void Update()
    {
        MoveVec.x = _input.InputX;
        MoveVec.y = _input.InputY;
    }

    private void FixedUpdate()
    {
        NomalVec = MoveVec.normalized;
        _rigidbody.MovePosition(_rigidbody.position + NomalVec);
    }
}
