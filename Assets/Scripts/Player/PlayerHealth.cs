using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private PlayerStats _playerStats;

    [SerializeField] TextMeshProUGUI _textHealthValue;
    [SerializeField] TextMeshProUGUI _textShieldValue;

    private void Start()
    { 
        _playerStats = GetComponent<PlayerStats>();
        SetText();
    }

    public void TakeDamage(int damage)
    {
        if ( _playerStats.health <= 20)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if ( _playerStats.playerShield > 0 )
        {
            _playerStats.playerShield -= damage;
        }
        else
        {
            _playerStats.health -= damage;
        }

        SetText();
    }

    public void SetText()
    {
        _textHealthValue.text = $"Health: {_playerStats.health}";
        _textShieldValue.text = $"Shield: {_playerStats.playerShield}";    
    }
}
