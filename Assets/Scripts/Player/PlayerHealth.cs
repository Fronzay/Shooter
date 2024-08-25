using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private PlayerStats _playerStats;

    [SerializeField] TextMeshProUGUI _textHealthValue;
    [SerializeField] TextMeshProUGUI _textShieldValue;

    [SerializeField] GameObject _panelYoiDeatch;

    private void Start()
    { 
        _playerStats = GetComponent<PlayerStats>();
        SetText();
    }

    public void TakeDamage(int damage)
    {
        if ( _playerStats.health <= 20)
            ActivatePanel();
        

        if ( _playerStats.playerShield > 0 )
        {
            if ( _playerStats.playerShield != 10)
                _playerStats.playerShield -= damage;

            
            if ( _playerStats.playerShield == 10)
            {
                _playerStats.playerShield -= (damage - 10);
            }
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

    private void ActivatePanel()
    {
        _panelYoiDeatch.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        GetComponentInChildren<MouseController>().enabled = false;
    }
}
