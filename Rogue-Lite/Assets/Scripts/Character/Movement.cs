using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private CharacterInput _input;
    private Status _status;
    private SpriteRenderer _renderer;

    private Vector2 MoveVec;
    private Vector2 NomalVec;
    private Vector2 MovePosition;

    public float VectorX { get { return MoveVec.x; } }
    public float VectorY { get { return MoveVec.y; } }

    private float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<CharacterInput>();
        _status = GetComponent<Status>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _speed = _status.GetSpeed();
    }

    private void Update()
    {
        MoveVec.x = _input.InputX;
        MoveVec.y = _input.InputY;
    }

    private void FixedUpdate()
    {
        NomalVec = MoveVec.normalized;
        MovePosition = _speed * Time.fixedDeltaTime * MoveVec;
        _rigidbody.MovePosition(_rigidbody.position + MovePosition);
    }

    private void LateUpdate()
    {
        if(MoveVec.x != 0)
        {
            _renderer.flipX = MoveVec.x < 0;
        }
    }
}
