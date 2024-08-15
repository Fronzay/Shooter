using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private int _vibration;
    [SerializeField] private float _strenght;

    public void ShakeEffect()
    {
        transform.DOShakePosition(_duration, _strenght, _vibration);
    }
}
