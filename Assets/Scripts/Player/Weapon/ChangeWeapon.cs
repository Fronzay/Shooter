using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeaponIndex;


    [SerializeField] private AmmoStorage _ammoStorage;
    [SerializeField] private WeaponShoot _weaponShoot;

    private void Start()
    { 
        SelectWeapon();
    }

    private void Update()
    {
        int previousWeaponIndex = currentWeaponIndex;


        ChangeMouse();
        ChangeKeboard();


        if (previousWeaponIndex != currentWeaponIndex && !_ammoStorage.reloadWeapon && !_weaponShoot.reloadWeaponFire)
        {
            SelectWeapon();
            _ammoStorage.SetText();
        }
    }

    private void SelectWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == currentWeaponIndex);
        }

        _ammoStorage = GetComponentInChildren<AmmoStorage>();
        _weaponShoot = GetComponentInChildren<WeaponShoot>();
    }

    private void ChangeMouse()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentWeaponIndex++;

            if (currentWeaponIndex >= weapons.Length)
            {
                currentWeaponIndex = 0;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentWeaponIndex--;

            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = weapons.Length - 1;
            }
        }
    }

    private void ChangeKeboard() 
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && weapons.Length >= 2)
        {
         
            currentWeaponIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && weapons.Length >= 3)
        {
           
            currentWeaponIndex = 2;
        }
    }
}
