using TMPro;
using UnityEngine;
using UnityEngine.UI;
//-------------------------{ sigmo coding - SRV }-------------------------

namespace Menu.Authors {
    public class AuthorItemView : MonoBehaviour {
        [SerializeField]
        private RawImage _avatar;

        [SerializeField]
        private TextMeshProUGUI _name;

        [SerializeField]
        private TextMeshProUGUI _work;

        [SerializeField]
        private Button _url;

        public string Url { get; set; }

        private void Start() {
            _url.onClick.AddListener(() => Application.OpenURL(Url));
        }

        public void Init(Author author) {
            _avatar.texture = author.m_avatar;
            _name.text = author.m_name;
            _work.text = author.m_work;
            Url = author.m_url;
        }
    }
}