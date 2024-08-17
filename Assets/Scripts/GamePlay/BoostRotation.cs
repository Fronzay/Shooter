using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostRotation : MonoBehaviour
{

    [SerializeField] float _speedRotationY, _speedRotationZ;

    private void Update() => Rotate();
    
    private void Rotate() => transform.Rotate(0, _speedRotationY * Time.deltaTime, _speedRotationZ * Time.deltaTime);
}
