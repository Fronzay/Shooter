using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoStorage : MonoBehaviour
{
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private TextMeshProUGUI _textStorageAmmo;

    [SerializeField] private Animator _animatorWeapon;

    [SerializeField] private int _currentValueAmmo = 15;
    [SerializeField] private int _maxValueAmmo = 15;
    [SerializeField] private int _ammoReserve = 300;
   
    private int _ammoRemained;

    [SerializeField] AudioSource _weaponReload;

    public int m_currentValueAmmo { get { return _currentValueAmmo; } set { _currentValueAmmo = value; } }
    public int m_ammoReserve { get { return _ammoReserve; } set { _ammoReserve = value; } }

    [SerializeField] float _timeReload;

    private bool _reloadWeapon;
    public bool reloadWeapon => _reloadWeapon;

    private void Start() => SetText();

    private void Update() => AmmoReload();
    
    public void SetText() => _textStorageAmmo.text = $"Ammo: {_currentValueAmmo}/{_ammoReserve}";

    private void AmmoReload()
    {
        if (_currentValueAmmo < _maxValueAmmo)
        {
            var inputR = Input.GetKeyDown(KeyCode.R);

            if ( inputR && !_reloadWeapon)
            {
                _ammoRemained = _maxValueAmmo - _currentValueAmmo;
                StartCoroutine(nameof(ReloadWeapon));
            }
        }
    }

    public void AmmoMinus(int ammoMinus)
    {
        _currentValueAmmo -= ammoMinus;
        SetText();
    }

    private IEnumerator ReloadWeapon()
    {
        _reloadWeapon = true;
        _animatorWeapon.Play("rig_reload");
        _weaponReload.PlayOneShot(_weaponReload.clip);
        _textStorageAmmo.text = $"Ammo: Reload... /{_ammoReserve}";
        yield return new WaitForSeconds(_timeReload);
        _currentValueAmmo += _ammoRemained;
        _ammoReserve -= _ammoRemained;
        SetText();
        _reloadWeapon = false;
    }

}
