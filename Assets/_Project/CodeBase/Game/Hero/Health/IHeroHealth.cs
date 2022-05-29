using System;

namespace CodeBase.Game.Hero.Health
{
    public interface IHeroHealth
    {
        event Action Died;
        void Kill();
    }
}