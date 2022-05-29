using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Game.Player
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private Player _player;
        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void OnEnable()
        {
            _inputService.MovedForward += _player.MoveRight;
            _inputService.MovedBack += _player.MoveLeft;
        }

        private void OnDisable()
        {
            _inputService.MovedForward -= _player.MoveRight;
            _inputService.MovedBack -= _player.MoveLeft;
        }
    }
}