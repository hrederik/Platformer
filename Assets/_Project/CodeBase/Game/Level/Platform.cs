using UnityEngine;

namespace CodeBase.Game.Level
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Transform _targetPoint;
        public Vector3 TargetPosition => _targetPoint.position;
    }
}