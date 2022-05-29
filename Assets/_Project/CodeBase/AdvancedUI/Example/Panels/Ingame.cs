using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AdvancedUI.Example.Panels
{
    [AddComponentMenu("CustomUI/Example//Panels/Ingame Panel")]
    public class Ingame : ShowableScreen
    {
        [SerializeField] private Button _nextLevel;
        private UnityAction _continueCallback;

        public void Init(UnityAction continueCallback)
        {
            _continueCallback = continueCallback;
        }
        
        private void OnEnable()
        {
            _nextLevel.onClick.AddListener(OnContinueClicked);
        }

        private void OnDisable()
        {
            _nextLevel.onClick.RemoveListener(OnContinueClicked);
        }

        public override void Show() { }
        public override Coroutine Hide() => StartEmptyCoroutine();

        private void OnContinueClicked()
        {
            _continueCallback?.Invoke();
        }
    }
}