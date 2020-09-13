using IJunior.TypedScenes;
using UnityEngine;

public class GameState : MonoBehaviour, ISceneLoadHandler<GamePreset>
{
    [SerializeField] private Player _player;
    [SerializeField] private IngameInterface _ingameInterface;

    private void OnEnable()
    {
        _player.Died += Lose;
        _player.TreasureCollected += Win;
    }

    private void OnDisable()
    {
        _player.Died -= Lose;
        _player.TreasureCollected -= Win;
    }

    public void Win()
    {
        _ingameInterface.ShowWinPanel();
    }

    public void Lose()
    {
        _ingameInterface.ShowLosePanel();
    }

    public void OnSceneLoaded(GamePreset gamePreset)
    {
        _player.Initialize(gamePreset.PlayerPrefab);
    }
}