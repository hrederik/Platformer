using UnityEngine;

namespace AdvancedUI
{
    public abstract class UIMediator : MonoBehaviour
    {
        private ScreensSwitcher _switcher;

        private void Awake()
        {
            _switcher = new ScreensSwitcher(this);
            Awoke();
        }

        public void HideUI()
        {
            _switcher.HideLast();
        }

        protected UIScreen ShowScreen(UIScreen screen) =>
            _switcher.Show(screen);

        protected void HideLastScreen() =>
            _switcher.HideLast();
        
        protected virtual void Awoke() { }
    }
}