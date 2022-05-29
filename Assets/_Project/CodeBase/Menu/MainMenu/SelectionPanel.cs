using UnityEngine;

namespace CodeBase.Menu.MainMenu
{
    public class SelectionPanel : OpenablePanel
    {
        [SerializeField] private MainMenuPanel _mainMenuPanel;

        public void OpenCustomizationPanel(OpenablePanel panel)
        {
            Close();
            panel.Open();
        }
    }
}