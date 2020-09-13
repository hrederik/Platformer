using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Player : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private Animator _animator;
    private Transform _transform;
    private Coroutine _motion;
    private float _speed;

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
        _speed = player.Speed;
    }

    public void MoveLeft()
    {
        _transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

        if (_level.HasPreviousPlatform == true)
        {
            StopMotion();

            Platform previousPlatform = _level.GetPreviousPlatform();
            _motion = StartCoroutine(Move(previousPlatform.TargetPosition));
        }
    }

    public void MoveRight()
    {
        _transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        if (_level.HasNextPlatform == true)
        {
            StopMotion();

            Platform nextPlatform = _level.GetNextPlatform();
            _motion = StartCoroutine(Move(nextPlatform.TargetPosition));
        }
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

    private void StopMotion()
    {
        if (_motion != null)
        {
            StopCoroutine(_motion);
            _motion = null;
        }
    }

    private IEnumerator Move(Vector3 targetPosition)
    {
        _animator.SetBool("IsMove", true);

        while (_transform.position.x != targetPosition.x)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, targetPosition, Time.fixedDeltaTime * _speed);
            yield return new WaitForFixedUpdate();
        }

        _animator.SetBool("IsMove", false);
    }
} 