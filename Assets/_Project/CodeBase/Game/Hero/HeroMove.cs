using CodeBase.Game.Hero.Animator;
using CodeBase.Game.Level.Platforms;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace CodeBase.Game.Hero
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private Ease _ease;
        private IPlatformsIterator _platformsIterator;
        private IInputService _inputService;
        private IHeroAnimator _heroAnimator;
        private Transform _transform;
        private Tween _motion;
        private float _speed;

        [Inject]
        public void Construct(
            IInputService inputService,
            IPlatformsIterator platformsIterator,
            IHeroStaticDataLoader heroStaticDataLoader,
            IHeroAnimator heroAnimator)
        {
            _inputService = inputService;
            _platformsIterator = platformsIterator;
            _speed = heroStaticDataLoader.Chosen.Speed;
            _heroAnimator = heroAnimator;
        }

        private void Awake() => 
            _transform = GetComponent<Transform>();

        private void OnEnable()
        {
            _inputService.MovedForward += OnMovedForward;
            _inputService.MovedBack += OnMovedBack;
        }

        private void OnDisable()
        {
            _inputService.MovedForward -= OnMovedForward;
            _inputService.MovedBack -= OnMovedBack;
        }

        private void OnMovedForward()
        {
            LookForward();
            if (!_platformsIterator.HasNextPlatform) return;
            
            StopMotion();
            MoveToPlatform(_platformsIterator.GetNextPlatform());
        }

        private void OnMovedBack()
        {
            LookBack();
            if (!_platformsIterator.HasPreviousPlatform) return;
            
            StopMotion();
            MoveToPlatform(_platformsIterator.GetPreviousPlatform());
        }

        private void StopMotion() => 
            _motion.Kill();

        private void MoveToPlatform(Platform nextPlatform)
        {
            var duration = Vector3.Distance(_transform.position, nextPlatform.TargetPosition) / _speed;
            _heroAnimator.PlayMotion();
            _motion = _transform
                .DOMoveX(nextPlatform.TargetPosition.x, duration)
                .SetEase(_ease)
                .OnComplete(_heroAnimator.PlayIdle);
        }

        private void LookForward() => 
            _transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        private void LookBack() => 
            _transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }
}