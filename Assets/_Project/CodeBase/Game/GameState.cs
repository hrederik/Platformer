using CodeBase.Game.Hero.Health;
using CodeBase.Game.Level;
using UnityEngine;
using Zenject;

namespace CodeBase.Game
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private IngameInterface _ingameInterface;
        private IHeroHealth _heroHealth;
        private ILevelFinish _levelFinish;

        [Inject]
        public void Construct(IHeroHealth heroHealth, ILevelFinish levelFinish)
        {
            _heroHealth = heroHealth;
            _levelFinish = levelFinish;
        }
        
        private void OnEnable()
        {
            _heroHealth.Died += Lose;
            _levelFinish.Reached += Win;
        }

        private void OnDisable()
        {
            _heroHealth.Died -= Lose;
            _levelFinish.Reached -= Win;
        }

        private void Win()
        {
            _ingameInterface.ShowWinPanel();
        }

        private void Lose()
        {
            _ingameInterface.ShowLosePanel();
        }
    }
}