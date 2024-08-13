using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] CharacterController _characterController;

    Vector3 direction;

    void Update()
    {
        InputRead();
        Move();
    }

    private void InputRead()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        direction = transform.right * moveX + transform.forward * moveZ;
    }

    private void Move()
    {
        _characterController.Move(direction * _speed * Time.deltaTime);
    }
}
