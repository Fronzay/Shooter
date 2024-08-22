using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    private DropItems _dropItems;

    [SerializeField] int _health;
    public int health => _health;
    
    [SerializeField] int _valueTakeDamage;

    private void Start()
    {
        _dropItems = FindAnyObjectByType<DropItems>();
    }

    public void GetDamage()
    {
        if (_health <= 0)
        {
            GameManager.Instance.m_currentDeatchEnemy++;

            Vector3 position = new Vector3 (transform.position.x, transform.position.y + 5, transform.position.z);

            this.transform.position = position;

            _dropItems.Drop(this.transform);

            Destroy(this.gameObject);
        }

        _health -= _valueTakeDamage;
    }

}