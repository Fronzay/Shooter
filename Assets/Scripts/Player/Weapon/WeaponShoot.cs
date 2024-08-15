using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    private CameraShake _cameraShake;
    private AmmoStorage _ammoStorage;
    [SerializeField] private WeaponData _weaponData;
    

    [SerializeField] private Transform _pointBullet;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _fireWeapon;

    [SerializeField] GameObject _shootEffect;

    [SerializeField] private float _shootCooldown;
    [SerializeField] private float _shootEffectLifeTime;

    private bool _reload;

    private void Start()
    {
        _cameraShake = GetComponentInParent<CameraShake>();
        _ammoStorage = GetComponentInParent<AmmoStorage>();
    }
    
    private void Update() => ShootCooldown();

    private void PlaySoundFire() => _fireWeapon.PlayOneShot(_fireWeapon.clip);

    private void ShootCooldown()
    {
        var input = Input.GetMouseButtonDown(0);

        if (input && !_reload && _ammoStorage.m_currentValueAmmo >= 1)
        {
            StartCoroutine(nameof(Shoot));
        }
    }

    private IEnumerator Shoot()
    {
        StartCoroutine(nameof(ShootEffect));

        _reload = true;

        _cameraShake.ShakeEffect();

        PlaySoundFire();

        if (_animator != null) _animator.Play("rig_shot");

        Instantiate(_weaponData.m_prefabBullet, _pointBullet.position, _pointBullet.rotation);

        _ammoStorage.AmmoMinus(1);
        yield return new WaitForSeconds(_shootCooldown);
        _reload = false;
    }

    private IEnumerator ShootEffect()
    {
        _shootEffect.SetActive(true);
        yield return new WaitForSeconds(_shootEffectLifeTime);
        _shootEffect.SetActive(false);
        yield break;
    }
}
