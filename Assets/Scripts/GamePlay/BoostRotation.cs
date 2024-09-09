using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostRotation : MonoBehaviour
{

    [SerializeField] float _speedRotationY, _speedRotationZ;

    private Vector3 _vector;


    private void Update() => Rotate();
    
    private void Rotate() {
        /* if(gameObject.name == "shield(Clone)") {
             transform.Rotate(-90, _speedRotationY * Time.deltaTime, _speedRotationZ * Time.deltaTime);
         }
         else
             transform.Rotate(0, _speedRotationY * Time.deltaTime, _speedRotationZ * Time.deltaTime);*/
        // ---------------------------[Ну вы пон как фиксить shield]---------------------------
        transform.Rotate(0, _speedRotationY * Time.deltaTime, _speedRotationZ * Time.deltaTime);
    }
}
