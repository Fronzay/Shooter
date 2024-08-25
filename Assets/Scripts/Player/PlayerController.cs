using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;

    [SerializeField] private Move _movePlayer;
    [SerializeField] private Gravity _jumpPlayer;


    private void Update()
    {
        _jumpPlayer.UseGravity(_characterController);


        _movePlayer.InputRead();
        _movePlayer.PlayerBoostSpeed();
        _movePlayer.PlayerMove(_characterController);
    }
   
}
