using CodeBase.Infrastructure.Services.HeroDataProvider;
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
            BindHeroDataProvider();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .FromComponentInNewPrefab(_inputService)
                .AsSingle();
        }

        private void BindHeroDataProvider()
        { 
            Container
                .Bind<IStaticDataService>()
                .To<DefaultStaticDataService>()
                .AsSingle();
        }
    }
}