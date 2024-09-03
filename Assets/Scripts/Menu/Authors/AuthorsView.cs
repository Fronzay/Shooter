using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Authors {

    [Serializable]
    public class Author {
        [SerializeField]
        private string _name;

        [SerializeField]
        private string _work;

        [SerializeField]
        private string _url;

        [SerializeField]
        private Texture2D _avatar;

        public string m_name => _name;
        public string m_work => _work;
        public string m_url => _url;
        public Texture2D m_avatar => _avatar;
    }
    [RequireComponent(typeof(Animator))]
    public class AuthorsView : MonoBehaviour {
        [SerializeField]
        private List<Author> _authors;

        [SerializeField]
        private AuthorItemView _authorItemView;

        [SerializeField]
        private Transform _contentSpawn;

        [SerializeField]
        private Button _closeButton;

        [SerializeField]
        private Animator _menu;

        private Animator _animator; 

        private void Start() {
            SpawnAllAuthor();
            _closeButton.onClick.AddListener(HideAnimation);
            _animator = GetComponent<Animator>();
        }

        private void HideAnimation() {
            //_animator.SetTrigger("Hide");
            _animator.Play("HideView");
            Invoke("Hide", 0.4f);
        }

        private void Hide() {
            gameObject.SetActive(false);
            Invoke("ShowAnimation", 0.1f);
        }

        private void ShowAnimation() {
            _menu.Play("HideView");
            _menu.gameObject.SetActive(true);
        }

        private void OnEnable() {
            _menu.gameObject.SetActive(false);
        }

        private void SpawnAllAuthor() {
            for(int i = 0; i < _authors.Count; i++) {
                var author = Instantiate(_authorItemView, _contentSpawn);
                author.Init(_authors[i]);
            }
        }
            
    }
}