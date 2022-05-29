﻿using UnityEngine;

namespace CodeBase.Game.Player
{
    [RequireComponent(typeof(Transform))]
    public class TargetFollowing : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _target;
        private Transform _transform;
        private float _offset;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _offset = _transform.position.x - _target.position.x;
        }

        private void Update()
        {
            Vector3 newPosition = new Vector3(_target.position.x + _offset, _transform.position.y, _transform.position.z);
            _transform.position = Vector3.MoveTowards(_transform.position, newPosition, _speed * Time.deltaTime);
        }
    }
}