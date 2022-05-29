using CodeBase.Game.Hero.Health;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Game.Level.Interactables
{
    public class Spikes : Interactable
    {
        [SerializeField] private float _showDelay = 2;
        [SerializeField] private float _showDuration = 1.0f;
        [SerializeField] private Ease _show;
        [Space]
        [SerializeField] private float _hideDelay = 0.5f;
        [SerializeField] private float _hideDuration = 0.5f;
        [SerializeField] private Ease _hide;

        [Space]
        [SerializeField] private float _showedPosition;
        [SerializeField] private float _hidPosition;
        [SerializeField] private Transform _spikes;

        private void Start() => Animate();

        protected override void OnEntered(IHeroHealth heroHealth) => 
            heroHealth.Kill();

        protected override void OnExited(IHeroHealth _) { }

        private void Animate()
        {
            var sequence = DOTween.Sequence();
            sequence
                .AppendInterval(_showDelay)
                .Append(
                    _spikes
                        .DOMoveY(_showedPosition, _showDuration)
                        .SetEase(_show))
                .AppendInterval(_hideDelay)
                .Append(
                    _spikes
                        .DOMoveY(_hidPosition, _hideDuration)
                        .SetEase(_hide))
                .SetLoops(-1);
        }
    }
}