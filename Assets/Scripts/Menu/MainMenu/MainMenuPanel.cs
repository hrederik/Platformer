using IJunior.TypedScenes;
using UnityEngine;

public class MainMenuPanel : OpenablePanel
{
    [SerializeField] private GamePreset _gamePreset;
    [SerializeField] private SelectionPanel _selectionPanel;

    public void OnPlayButtonClick()
    {
        Game.Load(_gamePreset);
    }

    public void OnCustomizationButtonClick()
    {
        Close();
        _selectionPanel.Open();
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}