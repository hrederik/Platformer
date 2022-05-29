using System;
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

        public void Initialize(PlayerPrefab playerPrefab)
        {
            PlayerPrefab player = Instantiate(playerPrefab, transform);

            _heroAnimator.Initialize(player.Animator);
            _heroMove.Initialize(player.Speed, _level);
        }

        public void Kill()
        {
            _heroAnimator.PlayDeath();
            Died?.Invoke();
        }
    }
} 