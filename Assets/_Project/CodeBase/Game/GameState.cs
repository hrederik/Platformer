using CodeBase.Game.Level;
using CodeBase.Game.Player;
using UnityEngine;
using Zenject;

namespace CodeBase.Game
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private Mediator _mediator;
        [SerializeField] private IngameInterface _ingameInterface;
        [SerializeField] private Treasure _treasure;

        [Inject]
        public void Construct(Mediator mediator)
        {
            _mediator = mediator;
        }
        
        private void OnEnable()
        {
            _mediator.Died += Lose;
            _treasure.Collected += Win;
        }

        private void OnDisable()
        {
            _mediator.Died -= Lose;
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