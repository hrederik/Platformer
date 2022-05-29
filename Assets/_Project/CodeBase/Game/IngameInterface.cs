using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Game
{
    public class IngameInterface : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _winPanel;

        public void ShowWinPanel()
        {
            _winPanel.SetActive(true);
        }

        public void ShowLosePanel()
        {
            _gameOverPanel.SetActive(true);
        }

        public void OpenMainMenu()
        {
            SceneManager.LoadScene(SceneNames.Menu);
        }
    }
}