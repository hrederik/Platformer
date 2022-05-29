using UnityEngine;

namespace CodeBase.Game
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private HeroPreset _heroPreset;
        [SerializeField] private IngameInterface _ingameInterface;

        private void OnEnable()
        {
            _player.Died += Lose;
            _player.TreasureCollected += Win;
        }

        private void Start()
        {
            _player.Initialize(_heroPreset.Prefab);
        }

        private void OnDisable()
        {
            _player.Died -= Lose;
            _player.TreasureCollected -= Win;
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