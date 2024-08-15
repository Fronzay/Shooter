using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSetDamage : MonoBehaviour
{
    private Health _health;
    private AddScore _score;

    private void Start()
    {
        _score = FindAnyObjectByType<AddScore>();
    }


    private void OnTriggerEnter(Collider other)
    {
        _health = other.GetComponent<Health>();

        if (_health.health <= 0)
        {
            _score.AddScoreTypeEnemy(other);
        }

        Damage(other);
    }

    private void Damage(Collider col)
    {
        var detection = col.TryGetComponent(out IDamagable damage);

        if (detection)
        {
            damage.GetDamage();
            Destroy(this.gameObject);
        }         
    }
}
