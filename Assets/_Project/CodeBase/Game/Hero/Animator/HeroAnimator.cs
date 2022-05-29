using UnityEngine;

namespace CodeBase.Game.Hero.Animator
{
    public class HeroAnimator : MonoBehaviour, IHeroAnimator
    {
        private static readonly int Moving = UnityEngine.Animator.StringToHash("Moving");
        private static readonly int Kill = UnityEngine.Animator.StringToHash("Kill");
        
        [SerializeField] private UnityEngine.Animator _animator;

        public void PlayMotion() => 
            _animator.SetBool(Moving, true);

        public void PlayIdle() => 
            _animator.SetBool(Moving, false);

        public void PlayDeath() => 
            _animator.SetTrigger(Kill);
    }
}