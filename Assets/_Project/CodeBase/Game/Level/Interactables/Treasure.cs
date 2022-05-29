using CodeBase.Game.Hero.Health;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Game.Level.Interactables
{
    public class Treasure : Interactable
    {
        private static readonly int Open = Animator.StringToHash("Open");
        
        [SerializeField] private Animator _animator;

        public event UnityAction Collected;

        protected override void OnEntered(IHeroHealth heroHealth)
        {
            _animator.SetTrigger(Open);
            Collected?.Invoke();
        }

        protected override void OnExited(IHeroHealth _) { }
    }
}