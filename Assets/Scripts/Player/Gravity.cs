using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravity;
    [SerializeField] private float _CurentGravity;

    private Vector3 _velocity;

    
    public void UseGravity(CharacterController _characterController)
    {
        Debug.Log(_velocity.y);
        _characterController.Move(_velocity * _gravity * Time.deltaTime);

        _velocity.y = -_gravity;


    }
}
