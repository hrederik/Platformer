using System;
using UnityEngine;

namespace CodeBase.Game.Player
{
    [RequireComponent(typeof(Transform))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private Level.Level _level;
        [SerializeField] private Animator _animator;
        private Transform _transform;
        private Coroutine _motion;
        
        public float Speed;

        public event Action Died;
        public event Action TreasureCollected;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        public void Initialize(PlayerPrefab playerPrefab)
        {
            PlayerPrefab player = Instantiate(playerPrefab, transform);
            _animator = player.Animator;
            Speed = player.Speed;
        }

        public void Kill()
        {
            _animator.SetTrigger("Kill");
            Died?.Invoke();
        }

        public void CollectTreasure()
        {
            TreasureCollected?.Invoke();
        }
    }
} 