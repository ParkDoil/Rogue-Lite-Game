using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private Vector3 _playerPos;
    private Vector3 _myPos;
    private Vector3 _dirVec;

    private float _distanceX;
    private float _distanceY;
    private float _dirX;
    private float _dirY;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("CheckGround"))
            return;
        
        _playerPos = GameManager.instance._player.transform.position;
        _myPos = transform.position;

        _distanceX = Mathf.Abs(_playerPos.x - _myPos.x);
        _distanceY = Mathf.Abs(_playerPos.y - _myPos.y);

        _dirVec.x = GameManager.instance._player.GetComponent<Movement>().VectorX;
        _dirVec.y = GameManager.instance._player.GetComponent<Movement>().VectorY;

        _dirX = _dirVec.x < 0 ? -1 : 1;
        _dirY = _dirVec.y < 0 ? -1 : 1;

        switch(transform.tag)
        {
            case "Ground":
                if(_distanceX > _distanceY)
                {
                    transform.Translate(Vector3.right * _dirX * 40);
                }
                else if (_distanceX < _distanceY)
                {
                    transform.Translate(Vector3.up * _dirY * 40);
                }
                break;
            case "Enemy":
                break;
        }
    }
}
