using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float _playerHealth = 100f;
    [SerializeField] private float _defaultSpeed;

    public float health {  get { return _playerHealth; } set { _playerHealth = value; } }   
    public float defaultSpeed {  get { return _defaultSpeed; } set { _defaultSpeed = value; } }   
    
}
