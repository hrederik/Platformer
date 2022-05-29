using CodeBase.Game.Level.Interactables;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Game.Level
{
    public class LevelFinish : MonoBehaviour, ILevelFinish
    {
        [SerializeField] private Treasure _treasure;

        public event UnityAction Reached
        {
            add => _treasure.Collected += value;
            remove => _treasure.Collected -= value;
        }
    }
}