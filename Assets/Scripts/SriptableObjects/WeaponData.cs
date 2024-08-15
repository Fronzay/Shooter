using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data", order = 51)]

public class WeaponData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _damage;
    [SerializeField] private int _ammoReserve;
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _prefabBullet;

    public string m_name => _name;
    public int m_damage => _damage;
    public int m_ammoReserve { get { return _ammoReserve; } set { _ammoReserve = value; } }
    public float m_delay => _delay;
    public GameObject m_prefabBullet => _prefabBullet;
}
