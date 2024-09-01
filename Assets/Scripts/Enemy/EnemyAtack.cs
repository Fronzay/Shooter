using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    private Detection _detection;
    private PlayerHealth _playerHealth;
    public bool isattak;
    [SerializeField] Animator _animator;

    [SerializeField] float _atackTime;
    [SerializeField] int _damage;

    [SerializeField] AudioSource _damagePlayer;

    private bool _reload;

    public Transform raycat;
    public GameObject Bulet;
    public float speadbulet;
    private void Start()
    {
        _detection = GetComponent<Detection>();
        _playerHealth = FindAnyObjectByType<PlayerHealth>();
    }

    private void Update()
    {
        Atack();
    }

    private void Atack()
    {
        if (_detection.m_playerDetection && !_reload)
        {
            if (isattak == false)
            {
                StartCoroutine(EnemyAtackPlayer());

            }
            else
            {
                StartCoroutine(EnemyAtacDistanskPlayer());

            }
        }
    }

    private IEnumerator EnemyAtackPlayer()
    {
        _reload = true;
        _animator.SetTrigger("Atack");
        yield return new WaitForSeconds(_atackTime);

        _damagePlayer.PlayOneShot(_damagePlayer.clip);

        if (_detection.m_playerDetection)
            _playerHealth.TakeDamage(_damage);

        yield return new WaitForSeconds(0.3f);
        _reload = false;
    }

    private IEnumerator EnemyAtacDistanskPlayer()
    {
        _reload = true;
        _animator.SetTrigger("Atack");
        yield return new WaitForSeconds(_atackTime);

        _damagePlayer.PlayOneShot(_damagePlayer.clip);
        if (_detection.m_playerDetection)
        {
            GameObject LocalBulet = Instantiate(Bulet, raycat.position,  Quaternion.identity);
            LocalBulet.GetComponent<Rigidbody>().velocity = Vector3.forward * speadbulet;
            LocalBulet.GetComponent<Bullet>()._damage = _damage;
            yield return new WaitForSeconds(0.3f);
            _reload = false;

        }
    }



}
