using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Game.Level
{
    public class Treasure : PlayerTrigger
    {
        private static readonly int Open = Animator.StringToHash("Open");
        
        [SerializeField] private Animator _animator;

        public event UnityAction Collected; 

        protected override void OnPlayerEnter(Player.Mediator mediator)
        {
            _animator.SetTrigger(Open);
            Collected?.Invoke();
        }
    }
}