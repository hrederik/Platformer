using UnityEngine;

namespace CodeBase.Game.Hero
{
    public class HeroMarker : MonoBehaviour
    {
        [SerializeField] private Transform _transform;

        public Vector3 Position => _transform.position;
    }
}