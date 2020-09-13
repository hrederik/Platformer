using UnityEngine;

public class PlayerPrefab : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    public float Speed => _speed;
    public Animator Animator => _animator;
}
