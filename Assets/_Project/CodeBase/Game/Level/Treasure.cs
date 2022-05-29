using CodeBase.Game.Hero.Health;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Game.Level
{
    public class Treasure : PlayerTrigger
    {
        private static readonly int Open = Animator.StringToHash("Open");
        
        [SerializeField] private Animator _animator;

        public event UnityAction Collected; 

        protected override void OnPlayerEnter(HeroHealth heroHealth)
        {
            _animator.SetTrigger(Open);
            Collected?.Invoke();
        }
    }
}