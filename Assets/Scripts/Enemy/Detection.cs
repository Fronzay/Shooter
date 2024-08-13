using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _maxDistance;

    public bool m_playerDetection => PlayerDetection();

    private bool PlayerDetection()
    {
        return Vector3.Distance(transform.position, _target.position) <= _maxDistance;
    }
}
