using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swaying : MonoBehaviour
{
    [SerializeField] float _weaponBobSpeed;
    [SerializeField] float _weaponBobAmount;

    private Vector3 originalPosition;

    void Start() => SetCurrentPosition();

    void Update() => SwayingGun();

    private void SetCurrentPosition() => originalPosition = transform.localPosition;

    private void SwayingGun()
    {
        float newBobY = Mathf.Cos(Time.time * _weaponBobSpeed) * _weaponBobAmount;

        transform.localPosition = originalPosition + new Vector3(0, newBobY, 0);
    }

}
