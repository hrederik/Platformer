using UnityEngine;

public class PlayerCustomizationPanel : OpenablePanel
{
    [SerializeField] private SelectionPanel _selectionPanel;
    [SerializeField] private GamePreset _gamePreset;
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

    public void Choose(PlayerPrefab playerPrefab)
    {
        _gamePreset.SetPlayerPrefab(playerPrefab);
    }
}