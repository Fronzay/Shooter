using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    private Detection _detection;
    private PlayerHealth _playerHealth;

    [SerializeField] Animator _animator;

    [SerializeField] float _atackTime;
    [SerializeField] int _damage;

    private bool _reload;

    private void Start()
    {
        _detection = GetComponent<Detection>();
        _playerHealth = FindAnyObjectByType<PlayerHealth>();
    }

    private void Update()
    {
        Atack();
    }

    private void Atack()
    {
        if (_detection.m_playerDetection && !_reload)
        {
            StartCoroutine(nameof(EnemyAtackPlayer));
        }
    }

    private IEnumerator EnemyAtackPlayer()
    {
        _reload = true;
        _animator.SetTrigger("Atack");
        yield return new WaitForSeconds(_atackTime);

        if (_detection.m_playerDetection)
            _playerHealth.TakeDamage(_damage);

        yield return new WaitForSeconds(0.5f);
        _reload = false;
    }
}
