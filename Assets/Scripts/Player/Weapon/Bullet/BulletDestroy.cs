using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField] private float _timeDestroy;

    private void Update() => Destroy();

    private void Destroy()
    {
        LeanGameObjectPool.Destroy(gameObject, _timeDestroy);
        //Destroy(this.gameObject, _timeDestroy);
    }
}

