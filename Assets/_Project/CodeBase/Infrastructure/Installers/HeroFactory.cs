using CodeBase.Game.Player;
using CodeBase.Infrastructure.Services.HeroDataProvider;
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
            var staticData = Container.Resolve<IStaticDataService>();
            var instance = Container.InstantiatePrefab(
                staticData.HeroData.Prefab,
                _spawnPoint.Position,
                _spawnPoint.Rotation, 
                null);
            
            return instance;
        }

        private GameObject InstantiateAndBindHeroBase()
        {
            var heroBase = SpawnHeroBase();
            Container.Bind<Mediator>().FromInstance(heroBase.GetComponent<Mediator>());
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