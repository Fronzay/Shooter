using UnityEngine;
using UnityEngine.UI;

namespace Game.Pause {
    public class PauseButton : MonoBehaviour {
        [SerializeField]
        private PauseView _pauseView;
        private bool isMenuOpen = false;

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pauseView.Ispause();
            }
        }

      
    }

}