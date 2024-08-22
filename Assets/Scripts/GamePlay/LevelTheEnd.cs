using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTheEnd : MonoBehaviour
{
    private SpawnEnemy _spawnEnemy;

    [SerializeField] Button _exit;

    [SerializeField] GameObject _panelTheEnd;

    private bool _theEnd;

    private void Start() => Init();


    private void Update() => TheEnd();

    private void TheEnd()
    {
        if (!_theEnd && GameManager.Instance.m_currentDeatchEnemy >= _spawnEnemy.m_maxEnemy)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Debug.Log("F");
            _panelTheEnd.SetActive(true);
            Time.timeScale = 0;
            _theEnd = true;
        }
    }

    private void Init()
    {
        _spawnEnemy = FindAnyObjectByType<SpawnEnemy>();

        _exit.onClick.AddListener(ClickExitButton);
    }

    private void ClickExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
