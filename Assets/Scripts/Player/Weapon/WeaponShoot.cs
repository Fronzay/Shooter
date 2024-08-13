using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] WeaponData _weaponData;
    [SerializeField] Transform _pointBullet;
    [SerializeField] Animator _animator;

    private void Update() => Shoot();
   

    private void Shoot()
    {
        var input = Input.GetMouseButtonDown(0);

        if (input)
        {
            if (_animator != null) _animator.Play("Shoot");

            Instantiate(_weaponData.m_prefabBullet, _pointBullet.position, _pointBullet.rotation);
        }
    }
}
