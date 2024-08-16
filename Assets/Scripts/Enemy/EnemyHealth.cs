using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] int _health;
    public int health => _health;
    
    [SerializeField] int _valueTakeDamage;

    public void GetDamage()
    {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }

        _health -= _valueTakeDamage;
    }

}