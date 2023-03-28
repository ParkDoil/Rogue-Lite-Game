using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScan : MonoBehaviour
{
    [SerializeField]
    private float _scanRange;
    [SerializeField]
    private LayerMask _target;
    private RaycastHit2D[] _hits;
    public Transform NearTarget { get; private set; }

    private void FixedUpdate()
    {
        _hits = Physics2D.CircleCastAll(transform.position, _scanRange, Vector2.zero, 0, _target);

        NearTarget = GetNearTarget();
    }

    private Transform GetNearTarget()
    {
        Transform answer = null;
        float distance = 1000f;

        foreach(RaycastHit2D target in _hits)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float targetDistance = Vector3.Distance(myPos, targetPos);

            if(targetDistance < distance)
            {
                distance = targetDistance;
                answer = target.transform;
            }
        }

        return answer;
    }
}
