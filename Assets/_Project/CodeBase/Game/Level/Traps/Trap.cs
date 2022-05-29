namespace CodeBase.Game.Level.Traps
{
    public class Trap : PlayerTrigger
    {
        protected override void OnPlayerEnter(Player.Mediator mediator)
        {
            mediator.Kill();
        }
    }
}