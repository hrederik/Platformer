namespace CodeBase.Game.Player
{
    public interface IHeroAnimator
    {
        void PlayMotion();
        void PlayIdle();
        void PlayDeath();
    }
}