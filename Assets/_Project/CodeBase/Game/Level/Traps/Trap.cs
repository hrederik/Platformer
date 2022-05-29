using CodeBase.Game.Hero.Health;

namespace CodeBase.Game.Level.Traps
{
    public class Trap : PlayerTrigger
    {
        protected override void OnPlayerEnter(HeroHealth heroHealth)
        {
            heroHealth.Kill();
        }
    }
}