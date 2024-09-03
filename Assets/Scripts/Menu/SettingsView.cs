using UnityEngine;
using UnityEngine.UI;

namespace Menu {
    public class SettingsView : MonoBehaviour {
        [SerializeField]
        private AudioSource[] _audioSound;

        [SerializeField]
        private AudioSource[] _audioMusic;

        [SerializeField]
        private Slider _sliderSensitivity;

        [SerializeField]
        private Slider _sliderSound;

        [SerializeField]
        private Slider _sliderMusic;

        [SerializeField]
        private Button _closeButton;

        [SerializeField]
        private Animator _menu;

        [SerializeField]
        private bool _isGame;

        private Animator _animator;

        private void Awake()
        {
            _sliderSensitivity.onValueChanged.AddListener(SetSensitivity);
            _sliderSound.onValueChanged.AddListener(SetSound);
            _sliderMusic.onValueChanged.AddListener(SetMusic);

            _sliderSound.value = PlayerPrefs.GetFloat("SliderVolumeValue");
            _sliderMusic.value = PlayerPrefs.GetFloat("SliderVolumeValueMusic");

            if(!_isGame)
                _closeButton.onClick.AddListener(HideAnimation);
            else
                _closeButton.onClick.AddListener(Hide);

            _animator = GetComponent<Animator>();
          
        }
        private void Update()
        {
            _sliderSound.onValueChanged.AddListener(SetSound);
            _sliderMusic.onValueChanged.AddListener(SetMusic);
        }
        private void HideAnimation() {
            //_animator.SetTrigger("Hide");
            _animator.Play("HideView");
            Invoke("Hide", 0.4f);
        }

        public void Hide() {
            gameObject.SetActive(false);
            Invoke("ShowAnimation", 0.1f);
        }

        private void ShowAnimation() {
            if(!_isGame) {
                _menu.Play("HideView");
                _menu.gameObject.SetActive(true);
            }
        }

        private void OnEnable() {
            if(!_isGame) {
                _menu.gameObject.SetActive(false);
            }
        }

        private void SetSensitivity(float newvalue) {
            PlayerPrefs.SetFloat("Sensitivity", newvalue);
        }

        private void SetSound(float newvalue) {
            PlayerPrefs.SetFloat("SliderVolumeValue", newvalue);
            for(int i = 0; i < _audioSound.Length; i++) {
                _audioSound[i].volume = newvalue;
            }
        }

        private void SetMusic(float newvalue) {
            PlayerPrefs.SetFloat("SliderVolumeValueMusic", newvalue);
            for (int i = 0; i < _audioMusic.Length; i++) {
                _audioMusic[i].volume = newvalue;
            }
        }
    }

}