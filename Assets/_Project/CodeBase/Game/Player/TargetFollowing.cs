using UnityEngine;
using Zenject;

namespace CodeBase.Game.Player
{
    [RequireComponent(typeof(Transform))]
    public class TargetFollowing : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private HeroMarker _hero;
        
        private Transform _transform;
        private float _offset;

        [Inject]
        public void Construct(HeroMarker heroMarker)
        {
            _hero = heroMarker;
        }
        
        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _offset = _transform.position.x - _hero.Position.x;
        }

        private void Update()
        {
            Vector3 newPosition = new Vector3(_hero.Position.x + _offset, _transform.position.y, _transform.position.z);
            _transform.position = Vector3.MoveTowards(_transform.position, newPosition, _speed * Time.deltaTime);
        }
    }
}