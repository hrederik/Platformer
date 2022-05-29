using UnityEngine;

namespace CodeBase.Spawn
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Transform _transform;

        public Vector3 Position => _transform.position;
    }
}