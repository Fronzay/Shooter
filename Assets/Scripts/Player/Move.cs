using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private PlayerStats _playerStats;

    private float _speed;

    private Vector3 direction;

    private bool _isBoosted;

    private void Start() => _playerStats = GetComponent<PlayerStats>();

    public void InputRead()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        direction = transform.right * moveX + transform.forward * moveZ;
        direction.Normalize();
    }

    public void PlayerMove(CharacterController _characterController)
    {
        _characterController.Move(direction * _speed * Time.deltaTime);
    }

    public void PlayerBoostSpeed()
    {
        var boostInput = Input.GetKey(KeyCode.LeftShift);

        if (boostInput && !_isBoosted) {

            _speed = _playerStats.defaultSpeed * 2;
            _isBoosted = true;
        }
        else
        {
            _speed = _playerStats.defaultSpeed;
            _isBoosted = false;
        }
        
    }
}
