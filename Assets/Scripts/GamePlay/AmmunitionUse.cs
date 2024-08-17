using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionUse : MonoBehaviour
{
    [SerializeField] int _AddAmmunitionValue;

    private AmmoStorage _ammoStorage;

    [SerializeField] AudioSource _useAmmunition;


    private void Start() => _ammoStorage = FindAnyObjectByType<AmmoStorage>();

    private void OnTriggerEnter(Collider col) => UseKit(col);

    private void UseKit(Collider player)
    {
        if (player.TryGetComponent(out PlayerStats stats) && _ammoStorage.m_ammoReserve <= 290)
        {
            _ammoStorage.m_ammoReserve += _AddAmmunitionValue;
            _useAmmunition.PlayOneShot(_useAmmunition.clip);
            _ammoStorage.SetText();
            Destroy(this.gameObject);
        }
    }
}
