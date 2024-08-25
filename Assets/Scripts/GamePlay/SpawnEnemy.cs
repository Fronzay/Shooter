using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] Transform[] _transform;

    [SerializeField] GameObject _enemyPrefab;

    [SerializeField] private int _maxEnemy;
    public int m_maxEnemy => _maxEnemy;

    [SerializeField] private float _spawnEnemy;
    [SerializeField] private float _currentAliveEnemy;
    [SerializeField] private float _maxAliveEnemy;

    public bool _reloadSpawn;

    private void Update()
    {
        UpdateEnemyValue();
        Spawn();
    }
    
    private void Spawn()
    {
       
        if ( _currentAliveEnemy < _maxAliveEnemy && GameManager.Instance.m_currentDeatchEnemy < 31)
        {
            Debug.Log("2");



            for (int i = 0; i < (_maxAliveEnemy - _currentAliveEnemy); i++)
            {
                Debug.Log("1");
                //Instantiate(_enemyPrefab, _transform[Random.Range(0, _transform.Length)].position, Quaternion.identity);
                LeanPool.Spawn(_enemyPrefab, _transform[Random.Range(0, _transform.Length)].position, Quaternion.identity);
            }
        }
    }

    private void UpdateEnemyValue()
    {
        _currentAliveEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

}
