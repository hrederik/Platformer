using CodeBase.Game.Player;
using CodeBase.Menu.Customization.Items;
using CodeBase.Menu.MainMenu;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Menu.Customization.Panels
{
    public class PlayerCustomizationPanel : OpenablePanel
    {
        [SerializeField] private HeroStaticData _heroStaticData;
        [SerializeField] private PlayerCustomizationItem[] _playerCustomizationItems;
        [SerializeField] private ItemScenePresenter _itemScenePresenterPrefab;
        [SerializeField] private RectTransform _container;
        private ItemScenePresenter[] _itemScenePresenters;

        private void Start()
        {
            _itemScenePresenters = new ItemScenePresenter[_playerCustomizationItems.Length];

            for (int i = 0; i < _playerCustomizationItems.Length; i++)
            {
                int z = i;

                _itemScenePresenters[i] = Instantiate(_itemScenePresenterPrefab, _container);
                _itemScenePresenters[i].Initialize(_playerCustomizationItems[i]);
                _itemScenePresenters[i].Choosen += () => Choose(_playerCustomizationItems[z].PlayerPrefab);
            }
        }

        public void Choose(HeroStaticData heroStaticData)
        {
            _heroStaticData = heroStaticData;
        }
    }
}