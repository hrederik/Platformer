using CodeBase.Game.Hero.Health;
using CodeBase.Game.Level;
using CodeBase.Game.Level.Interactables;
using UnityEngine;
using Zenject;

namespace CodeBase.Game
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private IngameInterface _ingameInterface;
        [SerializeField] private Treasure _treasure;
        private IHeroHealth _heroHealth;

        [Inject]
        public void Construct(IHeroHealth heroHealth)
        {
            _heroHealth = heroHealth;
        }
        
        private void OnEnable()
        {
            _heroHealth.Died += Lose;
            _treasure.Collected += Win;
        }

        private void OnDisable()
        {
            _heroHealth.Died -= Lose;
            _treasure.Collected -= Win;
        }

        public void Win()
        {
            _ingameInterface.ShowWinPanel();
        }

        public void Lose()
        {
            _ingameInterface.ShowLosePanel();
        }
    }
}