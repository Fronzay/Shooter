using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSetDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
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
