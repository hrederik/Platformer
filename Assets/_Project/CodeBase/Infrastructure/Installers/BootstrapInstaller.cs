using CodeBase.Infrastructure.Services;
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
            BindHeroStaticDataLoader();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .FromComponentInNewPrefab(_inputService)
                .AsSingle();
        }

        private void BindHeroStaticDataLoader()
        {
            Container
                .Bind<IHeroStaticDataLoader>()
                .To<HeroStaticDataLoader>()
                .AsSingle();
        }
    }
}