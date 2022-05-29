using AdvancedUI;
using CodeBase.AdvancedUI.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.AdvancedUI.Gameplay.Screens
{
    public class GameFail : SpawnableScreen
    {
        [SerializeField] private Button _button;

        public event UnityAction MainMenuClicked;
        
        private void OnEnable()
        {
            _button.AddListener(OnMainMenuClicked);
        }

        private void OnDisable()
        {
            _button.RemoveListener(OnMainMenuClicked);
        }

        public override void Show() { }

        public override Coroutine Hide() => StartEmptyCoroutine();

        private void OnMainMenuClicked()
        {
            MainMenuClicked?.Invoke();
        }
    }
}