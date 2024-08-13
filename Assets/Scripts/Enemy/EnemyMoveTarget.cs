using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveTarget : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] NavMeshAgent _enemy;

    private void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        _enemy.SetDestination(_target.position);
    }
}
