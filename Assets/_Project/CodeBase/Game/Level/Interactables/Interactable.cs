using CodeBase.Game.Hero.Health;
using UnityEngine;

namespace CodeBase.Game.Level.Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] private HealthTrigger _trigger;

        private void OnEnable()
        {
            _trigger.Entered += OnEntered;
            _trigger.Exited += OnExited;
        }

        protected abstract void OnEntered(IHeroHealth heroHealth);
        protected abstract void OnExited(IHeroHealth heroHealth);
    }
}