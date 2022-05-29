using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AdvancedUI
{
    public class ScreensSwitcher
    {
        private readonly UIMediator _mediator;
        private UIScreen _lastScreen;
        private UnityAction _hidingCallback;

        public ScreensSwitcher(UIMediator mediator)
        {
            _mediator = mediator;
        }
        
        public void Init(UIScreen firstScreen)
        {
            _lastScreen = firstScreen;
        }

        public UIScreen Show(UIScreen screen, UnityAction hidingCallback = null)
        {
            var instance = BuildInstance(screen);
            instance.Show();

            HideLast();
            _lastScreen = instance;
            _hidingCallback = hidingCallback;
            
            return instance;
        }

        public void HideLast()
        {
            if (_lastScreen == null) return;
            
            var hiding = _lastScreen.Hide();
            _mediator.StartCoroutine(HideAfterDelay(hiding, _lastScreen));
            _hidingCallback?.Invoke();
        }

        private UIScreen BuildInstance(UIScreen screen)
        {
            return screen is SpawnableScreen ? SpawnPanel(screen) : ActivatePanel(screen);
        }

        private UIScreen ActivatePanel(UIScreen screen)
        {
            screen.gameObject.SetActive(true);
            return screen;
        }

        private UIScreen SpawnPanel(UIScreen screen)
        {
            var instance = Object.Instantiate(screen, _mediator.transform);
            return instance;
        }

        private IEnumerator HideAfterDelay(Coroutine hiding, UIScreen screen)
        {
            yield return hiding;

            if (screen is SpawnableScreen)
                Object.Destroy(screen.gameObject);
            else
                screen.gameObject.SetActive(false);
        }
    }
}