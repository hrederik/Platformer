using CodeBase.Game.Hero.Health;
using CodeBase.Game.Level;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.AdvancedUI.Gameplay
{
    public class Presenter : MonoBehaviour
    {
        [SerializeField] private Mediator _mediator;
        private IHeroHealth _heroHealth;
        private ILevelFinish _levelFinish;

        [Inject]
        public void Construct(IHeroHealth heroHealth, ILevelFinish levelFinish)
        {
            _heroHealth = heroHealth;
            _levelFinish = levelFinish;
        }
        
        private void OnEnable()
        {
            _mediator.PlayClicked += OnPlayClicked;
            _mediator.MainMenuClicked += OnMainMenuClicked;

            _heroHealth.Died += OnHeroDied;
            _levelFinish.Reached += OnLevelFinishReached;
        }

        private void OnDisable()
        {
            _mediator.PlayClicked -= OnPlayClicked;
            _mediator.MainMenuClicked -= OnMainMenuClicked;
            
            _heroHealth.Died -= OnHeroDied;
            _levelFinish.Reached -= OnLevelFinishReached;
        }

        private void OnPlayClicked() => 
            _mediator.ShowIngame();

        private void OnMainMenuClicked() => 
            SceneManager.LoadScene(SceneNames.Menu);

        private void OnHeroDied() => 
            _mediator.ShowGameFail();

        private void OnLevelFinishReached() => 
            _mediator.ShowGameWin();
    }
}