using CodeBase.Game.Level;
using CodeBase.Game.Level.Platforms;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlatformsIterator _platformsIterator;
        [SerializeField] private LevelFinish _levelFinish;

        public override void InstallBindings()
        {
            BindPlatformsIterator();
            BindLevelFinish();
        }

        private void BindPlatformsIterator()
        {
            Container
                .Bind<IPlatformsIterator>()
                .FromInstance(_platformsIterator)
                .AsSingle();
        }

        private void BindLevelFinish()
        {
            Container
                .Bind<ILevelFinish>()
                .FromInstance(_levelFinish)
                .AsSingle();
        }
    }
}