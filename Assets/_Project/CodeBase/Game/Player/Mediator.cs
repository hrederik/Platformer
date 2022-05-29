using System;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Game.Player
{
    [AddComponentMenu("Gameplay/Hero")]
    public class Mediator : MonoBehaviour
    {
        [SerializeField] private Level.Level _level;
        [SerializeField] private HeroMove _heroMove;
        private HeroAnimator _heroAnimator;
        
        public event Action Died;

        public void Initialize(HeroStaticData heroStaticData)
        {
            Instantiate(heroStaticData.Prefab, transform);

            _heroAnimator.Initialize(heroStaticData.Animator);
            _heroMove.Initialize(heroStaticData.Speed, _level);
        }

        public void Kill()
        {
            _heroAnimator.PlayDeath();
            Died?.Invoke();
        }
    }
} 