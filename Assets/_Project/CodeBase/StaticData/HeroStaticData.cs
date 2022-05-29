using CodeBase.Game.Hero;
using UnityEngine;

namespace CodeBase.StaticData
{
    
    [CreateAssetMenu(menuName = "StaticData/Hero/HeroStaticData", fileName = "HeroStaticData", order = 0)]
    public class HeroStaticData : ScriptableObject
    {
        public string Name;
        public Sprite Sprite;
        public float Speed;
        public HeroSample Prefab;
    }
}