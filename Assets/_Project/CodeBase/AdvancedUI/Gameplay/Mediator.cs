using AdvancedUI;
using CodeBase.AdvancedUI.Gameplay.Screens;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.AdvancedUI.Gameplay
{
    [AddComponentMenu("CustomUI/Gameplay/Gameplay Mediator")]
    public class Mediator : UIMediator
    {
        [Header("Showable Screens")]
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private Ingame _ingame;

        [Header("Spawnable Screens")]
        [SerializeField] private GameWin _gameWin;
        [SerializeField] private GameFail _gameFail;

        public event UnityAction PlayClicked;
        public event UnityAction MainMenuClicked;

        private void OnEnable()
        {
            _mainMenu.PlayClicked += PlayClicked;
        }

        private void OnDisable()
        {
            _mainMenu.PlayClicked -= PlayClicked;
        }

        public void ShowMain()
        {
            ShowScreen(_mainMenu);
        }

        public void ShowIngame()
        {
            ShowScreen(_ingame);
        }

        public void ShowGameWin()
        {
            var instance = (GameWin) ShowScreen(_gameWin);
            instance.MainMenuClicked += MainMenuClicked;
        }

        public void ShowGameFail()
        {
            var instance = (GameFail) ShowScreen(_gameFail);
            instance.MainMenuClicked += MainMenuClicked;
        }
    }
}