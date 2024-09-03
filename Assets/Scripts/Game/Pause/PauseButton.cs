using UnityEngine;
using UnityEngine.UI;

namespace Game.Pause {
    [RequireComponent (typeof(Button))]
    public class PauseButton : MonoBehaviour {
        [SerializeField]
        private PauseView _pauseView;

        private Button _pauseButton;

        private void Awake() {
            _pauseButton = GetComponent<Button>();
            _pauseButton.onClick.AddListener(OpenPause);
        }

        private void FixedUpdate() {
            if (Input.GetKeyDown(KeyCode.P)) {
                OpenPause();
            }
        }

        private void OpenPause() {
            _pauseView.Show();
        }
    }

}