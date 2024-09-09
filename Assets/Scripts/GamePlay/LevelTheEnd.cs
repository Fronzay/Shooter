using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTheEnd : MonoBehaviour
{
    private SpawnEnemy _spawnEnemy;

    [SerializeField] Button _exit;
    public bool islockCursor;

    [SerializeField] GameObject _panelTheEnd;

   private List<GameObject> _enemyes = new List<GameObject>();

    public bool isEnd;
    private bool _theEnd;


    private void Start()
    {
        Init();
    }


    private void Update()
    {
        if (islockCursor == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        TheEnd(); }

    private void TheEnd()
    {
        if (!_theEnd && GameManager.Instance.m_currentDeatchEnemy >= _spawnEnemy.m_maxEnemy)
        {
            if (isEnd == true)
            {
                SceneManager.LoadScene("Menu");

            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                _theEnd = true;

            }
        }
    }

    private void Init()
    {
        _spawnEnemy = FindAnyObjectByType<SpawnEnemy>();

        _exit.onClick.AddListener(ClickExitButton);
    }

    public void ClickExitButton()
    {
        if (isEnd== true)
        {
            SceneManager.LoadScene("Menu");

        }
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // мб запускать сцену по ее названию? 
    }


    public void ExitGame() => Application.Quit();
   
}
