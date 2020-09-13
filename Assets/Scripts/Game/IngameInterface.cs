using IJunior.TypedScenes;
using UnityEngine;

public class IngameInterface : MonoBehaviour
{
    [SerializeField] private GameObject _ingamePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _winPanel;

    public void ShowWinPanel()
    {
        _ingamePanel.SetActive(false);
        _winPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        _ingamePanel.SetActive(false);
        _gameOverPanel.SetActive(true);
    }

    public void OpenMainMenu()
    {
        Menu.Load();
    }
}