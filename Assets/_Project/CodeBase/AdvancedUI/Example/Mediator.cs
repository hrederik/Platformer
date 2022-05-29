using UnityEngine;
using UnityEngine.Events;
using AdvancedUI.Example.Panels;

namespace AdvancedUI.Example
{
    [AddComponentMenu("CustomUI/Example/Example Mediator")]
    public class Mediator : UIMediator
    {
        [Header("Showable panels")]
        [SerializeField] private Ingame _ingame;

        [Header("Spawnable panels")]
        [SerializeField] private MainMenu _mainMenuPrefab;

        public event UnityAction PlayClicked;
        public event UnityAction ContinueClicked;
        
        private void Start()
        {
            ShowMainMenu();
        }

        public void ShowMainMenu()
        {
            var instance = (MainMenu)ShowScreen(_mainMenuPrefab);
            instance.Init(this, PlayClicked);
        }

        public void ShowIngame()
        {
            var instance = (Ingame)ShowScreen(_ingame);
            instance.Init(ContinueClicked);
        }
    }
}