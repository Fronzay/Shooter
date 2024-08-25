using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Detection : MonoBehaviour
{
    [SerializeField] private Transform _target, _pointCheckSpehere;
    [SerializeField] private float _maxDistance;
    [SerializeField] LayerMask _layerMask;

    [SerializeField] private int _offset;

    private bool _playerDetection;
    public bool m_playerDetection => _playerDetection;

    private void Update()
    {
        _playerDetection = Physics.CheckSphere(_pointCheckSpehere.position, _maxDistance, _layerMask);



        if (_playerDetection)
        {
            Debug.Log("Detection");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_pointCheckSpehere.position, _maxDistance);
        Gizmos.DrawLine(transform.position, _target.position - Vector3.right * _offset);
    }
}
