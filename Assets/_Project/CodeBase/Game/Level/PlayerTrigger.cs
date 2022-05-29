using UnityEngine;

namespace CodeBase.Game.Level
{
    public abstract class PlayerTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            Player.Player player = collider.GetComponent<Player.Player>();

            if (player)
            {
                OnPlayerEnter(player);
            }
        }

        protected abstract void OnPlayerEnter(Player.Player player);
    }
}