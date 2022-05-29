using System;
using CodeBase.Game.Hero.Animator;
using UnityEngine;
using Zenject;

namespace CodeBase.Game.Hero.Health
{
    public class HeroHealth : MonoBehaviour, IHeroHealth
    {
        private IHeroAnimator _heroAnimator;

        public event Action Died;

        [Inject]
        public void Construct(IHeroAnimator heroAnimator) => 
            _heroAnimator = heroAnimator;

        public void Kill()
        {
            _heroAnimator.PlayDeath();
            Died?.Invoke();
        }
    }
} 