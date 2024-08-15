using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoStorage : MonoBehaviour
{
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private TextMeshProUGUI _textStorageAmmo;

    [SerializeField] GameObject _textAmmoNull;

    [SerializeField] private int _currentValueAmmo = 30;
    public int m_currentValueAmmo { get { return _currentValueAmmo; } set { _currentValueAmmo = value; } }

    [SerializeField] float _timeReload;

    private void Start() => SetText();

    private void Update() => AmmoNull();
    
    private void SetText() => _textStorageAmmo.text = $"Ammo: {_currentValueAmmo}/{_weaponData.m_ammoReserve}";

    private void AmmoNull()
    {
        if (_currentValueAmmo <= 1)
        {
            var inputR = Input.GetKeyDown(KeyCode.R);

            if ( inputR )
            {
                _currentValueAmmo += 30;
                _weaponData.m_ammoReserve -= 30;
                SetText();
            }

            _textAmmoNull.SetActive(true);
        }
        else
            _textAmmoNull.SetActive(false);
    }

    public void AmmoMinus(int ammoMinus)
    {
        _currentValueAmmo -= ammoMinus;
        SetText();
    }

    private IEnumerator ReloadWeapon()
    {
        yield return new WaitForSeconds(_timeReload);
    }
    
}
