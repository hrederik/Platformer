using CodeBase.Game.Hero;
using CodeBase.Game.Hero.Animator;
using CodeBase.Game.Hero.Health;
using CodeBase.Infrastructure.Services;
using CodeBase.Spawn;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class HeroFactory : MonoInstaller
    {
        [SerializeField] private GameObject _heroBase;
        [SerializeField] private SpawnPoint _spawnPoint;

        public override void InstallBindings()
        {
            var heroSample = InstantiateAndBindHeroSample();
            var heroBase = InstantiateAndBindHeroBase();
            heroSample.transform.SetParent(heroBase.transform);
        }

        private GameObject InstantiateAndBindHeroSample()
        {
            var instance = SpawnHeroSample();
            Container.Bind<IHeroAnimator>().FromInstance(instance.GetComponent<HeroAnimator>());
            
            return instance;
        }

        private GameObject SpawnHeroSample()
        {
            var staticData = Container.Resolve<IHeroStaticDataLoader>();
            var instance = Container.InstantiatePrefab(
                staticData.Chosen.Prefab,
                _spawnPoint.Position,
                _spawnPoint.Rotation, 
                null);
            
            return instance;
        }

        private GameObject InstantiateAndBindHeroBase()
        {
            var heroBase = SpawnHeroBase();
            Container.Bind<IHeroHealth>().FromInstance(heroBase.GetComponent<HeroHealth>());
            Container.Bind<HeroMarker>().FromInstance(heroBase.GetComponent<HeroMarker>());
            
            return heroBase;
        }

        private GameObject SpawnHeroBase()
        {
            var heroBase = Container.InstantiatePrefab(
                _heroBase,
                _spawnPoint.Position,
                Quaternion.identity,
                null);
            
            return heroBase;
        }
    }
}