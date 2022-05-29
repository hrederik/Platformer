using CodeBase.Game.Player;
using UnityEngine;

namespace CodeBase
{
    public class GamePreset : MonoBehaviour
    {
        [SerializeField] private PlayerPrefab _playerPrefab;

        public PlayerPrefab PlayerPrefab => _playerPrefab;

        public void SetPlayerPrefab(PlayerPrefab playerPrefab)
        {
            _playerPrefab = playerPrefab;
        }
    }
}
