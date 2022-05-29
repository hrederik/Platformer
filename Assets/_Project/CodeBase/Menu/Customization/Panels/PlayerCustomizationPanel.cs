using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.HeroDataProvider;
using CodeBase.Menu.MainMenu;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Menu.Customization.Panels
{
    public class PlayerCustomizationPanel : OpenablePanel
    {
        [SerializeField] private ItemScenePresenter _itemScenePresenterPrefab;
        [SerializeField] private RectTransform _container;
        private ItemScenePresenter[] _itemScenePresenters;
        private IStaticDataService _staticDataService;
        private IHeroStaticDataLoader _heroStaticDataLoader;

        [Inject]
        public void Construct(IStaticDataService staticDataService, IHeroStaticDataLoader heroStaticDataLoader)
        {
            _staticDataService = staticDataService;
            _heroStaticDataLoader = heroStaticDataLoader;
        }
        
        private void Start()
        {
            var heroStaticData = _heroStaticDataLoader.LoadAll();
            _itemScenePresenters = new ItemScenePresenter[heroStaticData.Length];

            // TODO: Temp
            _staticDataService.HeroData = heroStaticData[0];
            
            for (int i = 0; i < heroStaticData.Length; i++)
            {
                int z = i;

                _itemScenePresenters[i] = Instantiate(_itemScenePresenterPrefab, _container);
                _itemScenePresenters[i].Initialize(heroStaticData[i].Name, heroStaticData[i].Sprite);
                _itemScenePresenters[i].Chosen += () => Choose(heroStaticData[z]);
            }
        }

        private void Choose(HeroStaticData heroStaticData)
        {
            _staticDataService.HeroData = heroStaticData;
        }
    }
}