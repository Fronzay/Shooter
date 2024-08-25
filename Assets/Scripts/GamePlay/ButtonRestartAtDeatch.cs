using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonRestartAtDeatch : MonoBehaviour
{

    [SerializeField] private Button _restart;

    void Start() => _restart.onClick.AddListener(OnCLickRestart);

    private void OnCLickRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
