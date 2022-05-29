namespace CodeBase.Game.Level.Traps
{
    public class Trap : PlayerTrigger
    {
        protected override void OnPlayerEnter(Player.Player player)
        {
            player.Kill();
        }
    }
}