public class Trap : PlayerTrigger
{
    protected override void OnPlayerEnter(Player player)
    {
        player.Kill();
    }
}