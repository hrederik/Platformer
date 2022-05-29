using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private SwipeInputService _inputService;

        public override void InstallBindings()
        {
            BindInputService();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .FromComponentInNewPrefab(_inputService)
                .AsSingle();
        }
    }
}