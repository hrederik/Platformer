using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AdvancedUI.Example.Panels
{
    [AddComponentMenu("CustomUI/Example//Panels/Main Menu Panel")]
    public class MainMenu : SpawnableScreen
    {
        [SerializeField] private Button _play;
        private UnityAction _playCallback;
        private Mediator _mediator;

        public void Init(Mediator mediator, UnityAction playCallback)
        {
            _mediator = mediator;
            _playCallback = playCallback;
        }

        private void OnEnable()
        {
            _play.onClick.AddListener(OnPlayClicked);
        }

        private void OnDisable()
        {
            _play.onClick.RemoveListener(OnPlayClicked);
        }

        public override void Show() { }
        public override Coroutine Hide() => StartEmptyCoroutine();

        private void OnPlayClicked()
        {
            _mediator.ShowIngame();
            _playCallback?.Invoke();
        }
    }
}