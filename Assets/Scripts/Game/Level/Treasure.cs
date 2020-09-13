using UnityEngine;

public class Treasure : PlayerTrigger
{
    [SerializeField] private Animator _animator;

    protected override void OnPlayerEnter(Player player)
    {
        _animator.SetTrigger("Open");
        player.CollectTreasure();
    }
}