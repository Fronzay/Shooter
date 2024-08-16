using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingKit : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    [SerializeField] AudioSource _useKit; 


    private void Start() => _playerHealth = FindAnyObjectByType<PlayerHealth>();
    
    private void OnTriggerEnter(Collider col) => UseKit(col);
    
    private void UseKit(Collider player)
    {
        if (player.TryGetComponent(out PlayerStats stats) && stats.health <= 85)
        {
            stats.health += 25;
            _useKit.PlayOneShot(_useKit.clip);
            _playerHealth.SetText();
            Destroy(this.gameObject);
        }
    }
}
