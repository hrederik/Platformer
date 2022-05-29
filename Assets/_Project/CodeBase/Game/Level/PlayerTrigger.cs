using CodeBase.Game.Hero.Health;
using UnityEngine;

namespace CodeBase.Game.Level
{
    public abstract class PlayerTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            HeroHealth heroHealth = collider.GetComponent<HeroHealth>();

            if (heroHealth)
            {
                OnPlayerEnter(heroHealth);
            }
        }

        protected abstract void OnPlayerEnter(HeroHealth heroHealth);
    }
}