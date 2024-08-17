using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUse : MonoBehaviour
{
    [SerializeField] float _addShieldValue;

    private PlayerHealth _playerHealth;

    [SerializeField] AudioSource _useShield;


    private void Start() => _playerHealth = FindAnyObjectByType<PlayerHealth>();

    private void OnTriggerEnter(Collider col) => UseKit(col);

    private void UseKit(Collider player)
    {
        if (player.TryGetComponent(out PlayerStats stats) && stats.playerShield <= 90)
        {
            stats.playerShield += _addShieldValue;
            _useShield.PlayOneShot(_useShield.clip);
            _playerHealth.SetText();
            Destroy(this.gameObject);
        }
    }
}
