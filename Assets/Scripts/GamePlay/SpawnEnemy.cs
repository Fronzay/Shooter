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
    public int totalenemy;

    [SerializeField] private float _spawnEnemy;
    [SerializeField] private float _currentAliveEnemy;
    [SerializeField] private float _maxAliveEnemy;
    private int IDSpawnPoint;

    public bool _reloadSpawn;

    private void Update()
    {
        UpdateEnemyValue();
        Spawn();
    }
    
    private void Spawn()
    {

        if (_currentAliveEnemy < _maxAliveEnemy && totalenemy < _maxEnemy)
        {
            for (int i = 0; i < _transform.Length; i++)
            {
                Instantiate(_enemyPrefab, _transform[i].position, Quaternion.identity);
                totalenemy++;
            }
            


        }
    }

    private void UpdateEnemyValue()
    {
        _currentAliveEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

}
