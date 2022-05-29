using AdvancedUI;
using UnityEngine;

namespace CodeBase.AdvancedUI.Gameplay.Screens
{
    public class Ingame : ShowableScreen
    {
        public override void Show() { }
        public override Coroutine Hide() => StartEmptyCoroutine();
    }
}