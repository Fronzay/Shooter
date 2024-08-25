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

   private List<GameObject> _enemyes = new List<GameObject>();  

    private bool _theEnd;

    private void Start() => Init();


    private void Update() => TheEnd();

    private void TheEnd()
    {
        if (!_theEnd && GameManager.Instance.m_currentDeatchEnemy >= _spawnEnemy.m_maxEnemy)
        {
            FindAnyObjectByType<MouseController>().enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
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
