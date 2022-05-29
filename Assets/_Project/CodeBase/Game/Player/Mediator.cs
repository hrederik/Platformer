using System;
using CodeBase.Infrastructure.Services.HeroDataProvider;
using UnityEngine;
using Zenject;

namespace CodeBase.Game.Player
{
    [AddComponentMenu("Gameplay/Hero")]
    public class Mediator : MonoBehaviour
    {
        [SerializeField] private Level.Level _level;
        [SerializeField] private HeroMove _heroMove;
        [SerializeField] private HeroAnimator _heroAnimator;
        private IStaticDataService _staticDataService;

        public event Action Died;

        [Inject]
        public void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        private void Start()
        {
            var data = _staticDataService.HeroData;
            var instance = Instantiate(data.Prefab, transform);

            _heroAnimator.Initialize(instance.Animator);
            _heroMove.Initialize(data.Speed, _level);
        }

        public void Kill()
        {
            _heroAnimator.PlayDeath();
            Died?.Invoke();
        }
    }
} 