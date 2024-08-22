using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSetDamage : MonoBehaviour
{
    private EnemyHealth _health;

    [SerializeField] GameObject _prefabBlood;


    private void OnTriggerEnter(Collider other)
    {
        _health = other.GetComponent<EnemyHealth>();

        if (other.TryGetComponent(out IScoreble scoreManager) && _health.health <= 0)
        {
            scoreManager.AddScore();
        }

        Damage(other);
    }

    private void Damage(Collider col)
    {
        var detection = col.TryGetComponent(out IDamagable damage);

        if (detection)
        { 

            Instantiate(_prefabBlood, transform.position, Quaternion.identity);
            damage.GetDamage();
            Destroy(this.gameObject);
        }         
    }
}
