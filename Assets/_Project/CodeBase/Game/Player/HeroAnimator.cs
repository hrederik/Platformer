using CodeBase.Infrastructure.Services.HeroDataProvider;
using UnityEngine;

namespace CodeBase.Game.Player
{
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int Moving = Animator.StringToHash("Moving");
        private static readonly int Kill = Animator.StringToHash("Kill");
        
        private Animator _animator;

        public void Initialize(Animator animator) => 
            _animator = animator;

        public void PlayMotion() => 
            _animator.SetBool(Moving, true);

        public void PlayIdle() => 
            _animator.SetBool(Moving, false);

        public void PlayDeath() => 
            _animator.SetTrigger(Kill);
    }
}