using CodeBase.Game.Level;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Game
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private Player.Mediator _mediator;
        [SerializeField] private HeroStaticData _heroStaticData;
        [SerializeField] private IngameInterface _ingameInterface;
        [SerializeField] private Treasure _treasure;


        private void Awake()
        {
            _mediator.Initialize(_heroStaticData);
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