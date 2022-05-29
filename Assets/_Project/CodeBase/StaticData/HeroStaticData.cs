using CodeBase.Game.Hero;
using UnityEngine;

namespace CodeBase.StaticData
{
    
    [CreateAssetMenu(menuName = "StaticData/Hero/HeroStaticData", fileName = "HeroStaticData", order = 0)]
    public class HeroStaticData : ScriptableObject
    {
        public float Speed;
        public HeroSample Prefab;
    }
}