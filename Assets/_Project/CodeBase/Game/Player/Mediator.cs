using System;
using UnityEngine;
using Zenject;

namespace CodeBase.Game.Player
{
    [AddComponentMenu("Gameplay/Hero")]
    public class Mediator : MonoBehaviour
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