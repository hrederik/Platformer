using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class HeroStaticDataLoader : IHeroStaticDataLoader
    {
        public HeroStaticData[] LoadAll() => 
            Resources.LoadAll<HeroStaticData>("StaticData/Hero/");
    }
}