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
    private int IDSpawnPoint;
    public int curentdat;
    public bool _reloadSpawn;

    private void Update()
    {
        UpdateEnemyValue();
        if (_currentAliveEnemy < _maxAliveEnemy)
        {
                            Spawn();

        }
           
        curentdat = GameManager.Instance.m_currentDeatchEnemy;

    }
    
    private void Spawn()
    {
        for (int i = 0; i< _transform.Length; i++)
            {
                Instantiate(_enemyPrefab, _transform[i].position, Quaternion.identity);
            }
            

    }

    private void UpdateEnemyValue()
    {
        _currentAliveEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

}
