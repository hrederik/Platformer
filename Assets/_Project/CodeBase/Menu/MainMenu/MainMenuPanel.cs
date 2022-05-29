using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Menu.MainMenu
{
    public class MainMenuPanel : OpenablePanel
    {
        [SerializeField] private SelectionPanel _selectionPanel;

        public void OnPlayButtonClick()
        {
            SceneManager.LoadScene(SceneNames.Game);
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
}