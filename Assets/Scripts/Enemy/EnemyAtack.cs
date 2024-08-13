using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    [SerializeField] private Detection _detection;

    [SerializeField] Animator _animator;

    private void Start()
    {
        _detection = GetComponent<Detection>();
    }

    private void Update()
    {
        Atack();
    }

    private void Atack()
    {
    }
}
