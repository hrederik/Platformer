using AdvancedUI;
using CodeBase.AdvancedUI.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.AdvancedUI.Gameplay.Screens
{
    [AddComponentMenu("CustomUI/Gameplay/Screens/Main menu")]
    public class MainMenu : ShowableScreen
    {
        [SerializeField] private Button _button;

        public event UnityAction PlayClicked;
        
        private void OnEnable()
        {
            _button.AddListener(OnPlayClicked);
        }

        private void OnDisable()
        {
            _button.RemoveListener(OnPlayClicked);
        }

        public override void Show() { }

        public override Coroutine Hide() => 
            StartEmptyCoroutine();

        private void OnPlayClicked()
        {
            PlayClicked?.Invoke();
        }
    }
}