using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravity;

    private Vector3 _velocity;

    
    public void Gravity(CharacterController _characterController)
    {

        //_characterController.Move(_velocity * _gravity);


        if (_characterController.isGrounded)
        {
            _gravity = -3;
        }
        else
        {
            _characterController.Move(_velocity * _gravity);
            _velocity.y -= _gravity * Time.deltaTime;
        }
    }
}
