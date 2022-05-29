using UnityEngine;

namespace CodeBase.Game.Level
{
    public class Treasure : PlayerTrigger
    {
        [SerializeField] private Animator _animator;

        protected override void OnPlayerEnter(Player.Player player)
        {
            _animator.SetTrigger("Open");
            player.CollectTreasure();
        }
    }
}