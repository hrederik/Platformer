namespace CodeBase.Game.Hero.Animator
{
    public interface IHeroAnimator
    {
        void PlayMotion();
        void PlayIdle();
        void PlayDeath();
    }
}