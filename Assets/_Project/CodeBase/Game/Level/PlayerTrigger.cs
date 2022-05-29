using UnityEngine;

namespace CodeBase.Game.Level
{
    public abstract class PlayerTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            Player.Mediator mediator = collider.GetComponent<Player.Mediator>();

            if (mediator)
            {
                OnPlayerEnter(mediator);
            }
        }

        protected abstract void OnPlayerEnter(Player.Mediator mediator);
    }
}