using CodeBase.Game.Player;
using UnityEngine;

namespace CodeBase
{
    
    [CreateAssetMenu(menuName = "HeroPreset", fileName = "HeroPreset", order = 0)]
    public class HeroPreset : ScriptableObject
    {
        public PlayerPrefab Prefab;
    }
}