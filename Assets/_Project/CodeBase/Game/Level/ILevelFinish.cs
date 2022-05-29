using UnityEngine.Events;

namespace CodeBase.Game.Level
{
    public interface ILevelFinish
    {
        event UnityAction Reached;
    }
}