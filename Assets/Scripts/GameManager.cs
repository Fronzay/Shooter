using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int _score;
    public int score { get { return _score; } set { _score = value; } }

    [SerializeField] private int _currentDeatchEnemy;
    public int m_currentDeatchEnemy {  get { return _currentDeatchEnemy; } set { _currentDeatchEnemy = value; } }

    [SerializeField] private TextMeshProUGUI _textScoreValue;
    public TextMeshProUGUI textScoreValue { get { return _textScoreValue; } set { _textScoreValue = value; } }

    [SerializeField] private Transform _playerTransform;
    public Transform m_playerTransform => _playerTransform;


    private void Awake()
    {
        Instance = this;
    }
}
