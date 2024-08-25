using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class WeaponShoot : MonoBehaviour
{
    private CameraShake _cameraShake;
    private AmmoStorage _ammoStorage;
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private ChangeWeapon _changeWeapon;


    [SerializeField] private Transform _pointBullet;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _fireWeapon;

    [SerializeField] string _animationString;

    [SerializeField] GameObject _shootEffect;

    [SerializeField] private float _shootCooldown;
    [SerializeField] private float _shootEffectLifeTime;

    [SerializeField] private int _maxPatronShoot;
    [SerializeField] private int _minusPatronShoot;

    [SerializeField] private float _spread;

    private bool _isAutomatic;

    private bool _reload;
    public bool reloadWeaponFire => _reload;

    private void Start()
    {
        _cameraShake = GetComponentInParent<CameraShake>();
        _ammoStorage = GetComponentInParent<AmmoStorage>();
        _changeWeapon = GetComponentInParent<ChangeWeapon>();
    }
    
    private void Update() => ShootCooldown();

    private void PlaySoundFire() => _fireWeapon.PlayOneShot(_fireWeapon.clip);

    private void ShootCooldown()
    {
        var input = Input.GetMouseButtonDown(0);
        var inputAutomatic = Input.GetMouseButton(0);

        if (input && !_reload && _ammoStorage.m_currentValueAmmo >= 1 && !_ammoStorage.reloadWeapon && !_weaponData.m_isAutomatic )
        {
            StartCoroutine(nameof(Shoot));
        }

        if (inputAutomatic && !_reload && _ammoStorage.m_currentValueAmmo >= 1 && !_ammoStorage.reloadWeapon && _weaponData.m_isAutomatic)
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

        if (_animator != null) _animator.Play(_animationString);

        SpawnBullet();

        _ammoStorage.AmmoMinus(_minusPatronShoot);

        yield return new WaitForSeconds(_shootCooldown);
        _reload = false;
    }

    private IEnumerator ShootEffect()
    {
        if (_shootEffect != null)
        {
            _shootEffect.SetActive(true);
            yield return new WaitForSeconds(_shootEffectLifeTime);
            _shootEffect.SetActive(false);
            yield break;
        }
    }

    private void SpawnBullet()
    {
        for (int i = 0; i < _minusPatronShoot; i++)
        {
            Debug.Log("Выстрел");
            //Instantiate(_weaponData.m_prefabBullet, _pointBullet.position, _pointBullet.rotation);
            LeanPool.Spawn(_weaponData.m_prefabBullet, _pointBullet.position, _pointBullet.rotation);
        }
    }
}
