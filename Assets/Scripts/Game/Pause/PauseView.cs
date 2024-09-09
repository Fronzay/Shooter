using Menu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Pause {
    public class PauseView : MonoBehaviour {
        [SerializeField]
        private Button _countineButton;

        [SerializeField]
        private Button _settingsButton;

        [SerializeField]
        private Button _exitToMenu;

        [SerializeField]
        private Button _Back;

        public GameObject MenuPaus;

        [SerializeField]
        private SettingsView _settingsView;

        private void Start () {
            _countineButton.onClick.AddListener(Hide);
            _settingsButton.onClick.AddListener(ShowSettings);
            _exitToMenu.onClick.AddListener(ExitMenu);
            _Back.onClick.AddListener(back);

        }

        public void Ispause()
        {
            if (!gameObject.activeSelf)
            { 
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            gameObject.SetActive(!gameObject.activeSelf);
            gameObject.SetActive(gameObject.activeSelf);
            _settingsView.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
            else
            {
                Hide();
            }
        }
        private void ShowSettings() {
            _settingsView.gameObject.SetActive(true);
            MenuPaus.SetActive(false);
            Time.timeScale = 0f;
        }

        public void Show() {
            Cursor.lockState = CursorLockMode.None;
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        private void OnDisable() {
            _settingsView.Hide();
        }

        public void Hide() {
            Cursor.lockState = CursorLockMode.Locked;
            gameObject.SetActive(false);
            MenuPaus.SetActive(true);
            Time.timeScale = 1f;
        }

        public void back()
        {
            _settingsView.gameObject.SetActive(false);
            gameObject.SetActive(true);
            MenuPaus.SetActive(true);
        }

        private void ExitMenu() {
            Hide();
            SceneManager.LoadScene("Menu");
        }
    }

}