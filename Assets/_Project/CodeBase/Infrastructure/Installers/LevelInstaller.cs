using CodeBase.Game.Level.Platforms;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlatformsIterator _platformsIterator;

        public override void InstallBindings()
        {
            BindPlatformsIterator();
        }

        private void BindPlatformsIterator()
        {
            Container
                .Bind<IPlatformsIterator>()
                .FromInstance(_platformsIterator)
                .AsSingle();
        }
    }
}