using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForce : MonoBehaviour
{
    [SerializeField] int _forceValue;

    private void Update() => Force();
    
    private void Force()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * _forceValue * Time.deltaTime);
    }
}
