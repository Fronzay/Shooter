using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveTarget : MonoBehaviour
{
    [SerializeField] NavMeshAgent _enemy;

    private void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        _enemy.SetDestination(GameManager.Instance.m_playerTransform.position);
    }
}
