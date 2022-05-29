using CodeBase.Game.Level;
using CodeBase.Infrastructure.Services.Input;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace CodeBase.Game.Player
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private HeroAnimator _heroAnimator;
        [SerializeField] private Ease _ease;
        private IInputService _inputService;
        private Transform _transform;
        private Level.Level _level;
        private Tween _motion;
        private float _speed;

        [Inject]
        public void Construct(IInputService inputService) => 
            _inputService = inputService;

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

        public void Initialize(float speed, Level.Level level)
        {
            _speed = speed;
            _level = level;
        }

        private void OnMovedForward()
        {
            LookForward();
            if (!_level.HasNextPlatform) return;
            
            StopMotion();
            MoveToPlatform(_level.GetNextPlatform());
        }

        private void OnMovedBack()
        {
            LookBack();
            if (!_level.HasPreviousPlatform) return;
            
            StopMotion();
            MoveToPlatform(_level.GetPreviousPlatform());
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