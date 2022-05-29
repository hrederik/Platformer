using DG.Tweening;
using UnityEngine;

namespace CodeBase.Game.Level.Traps
{
    public class Rockfall : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _acceleration;

        [Space]
        [SerializeField] private Vector3 _topPosition;
        [SerializeField] private float _bottomY;
        [SerializeField] private Transform _rock;
        [SerializeField] private TrailRenderer _trailRenderer;

        private void Start()
        {
            var sequence = DOTween.Sequence();

            sequence
                .AppendInterval(_delay)
                .AppendCallback(
                    () => _trailRenderer.enabled = true)
                .Append(
                    _rock
                        .DOMoveY(_bottomY, _duration)
                        .SetEase(_acceleration))
                .AppendCallback(
                    () =>
                    {
                        _trailRenderer.enabled = false;
                        _rock.localPosition = _topPosition;
                    })
                .AppendInterval(_delay)
                .SetLoops(-1);
        }
    }
}
