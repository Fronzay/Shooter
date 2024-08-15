using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private PlayerStats _playerStats;

    [SerializeField] TextMeshProUGUI _textHealth;

    private void Start()
    { 
        _playerStats = GetComponent<PlayerStats>();
        SetText();
    }

    public void TakeDamage(int damage)
    {
        if ( _playerStats.health <= 20)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        _playerStats.health -= damage;
        SetText();
    }

    private void SetText()
    {
        _textHealth.text = $"Health: {_playerStats.health}";    
    }
}
