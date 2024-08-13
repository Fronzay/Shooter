using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField] private float _timeDestroy;

    private void Update() => Destroy();

    private void Destroy()
    {
        Destroy(this.gameObject, _timeDestroy);
    }
}

