using Menu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Pause {
    public class PauseView : MonoBehaviour
    {
        [SerializeField]
        private Button _countineButton;

        [SerializeField]
        private Button _settingsButton;

        [SerializeField]
        private Button _MenuButton;


        [SerializeField]
        private Button _exitToMenu;

        [SerializeField]
        private SettingsView _settingsView;

        public GameObject menu;
        public GameObject menuCanvas;


        private void Start () {
            _countineButton.onClick.AddListener(Hide);
            _MenuButton.onClick.AddListener(Menu);
            _settingsButton.onClick.AddListener(ShowSettings);
            _exitToMenu.onClick.AddListener(ExitMenu);
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Show();
            }
        }

        private void ShowSettings() {
            Time.timeScale = 0f;
            _settingsView.gameObject.SetActive(true);
            menu.SetActive(false);
        }
        private void Menu()
        {
            _settingsView.gameObject.SetActive(false);
            menu.SetActive(true);

        }

        public void Show()
        {
            if (!menuCanvas.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                menuCanvas.SetActive(!menuCanvas.activeSelf);
                gameObject.SetActive(gameObject.activeSelf);
                _settingsView.gameObject.SetActive(false);
                menu.SetActive(true);


            }
            else
            {
                Hide();
            }
        }

        private void OnDisable()
        {
            _settingsView.Hide();
        }

        private void Hide()
        {
            menuCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }

        private void ExitMenu() {
            Hide();
            SceneManager.LoadScene("Menu");
        }
    }

}