using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.Menu.MainMenu
{
    public class ItemScenePresenter : MonoBehaviour
    {
        [SerializeField] private Text _name;
        [SerializeField] private Image _preview;
        [SerializeField] private Button _button;

        public event UnityAction Chosen
        {
            add => _button.onClick.AddListener(value);
            remove => _button.onClick.RemoveListener(value);
        }

        public void Initialize(string itemName, Sprite sprite)
        {
            _name.text = itemName;
            _preview.sprite = sprite;
        }
    }
}