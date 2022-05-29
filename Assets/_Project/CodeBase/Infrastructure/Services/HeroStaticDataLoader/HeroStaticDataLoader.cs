using System.Linq;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.HeroStaticDataLoader
{
    public class HeroStaticDataLoader : IHeroStaticDataLoader
    {
        private HeroStaticData[] _heroStaticData;

        public HeroStaticDataLoader()
        {
            _heroStaticData = Resources.LoadAll<HeroStaticData>("StaticData/Hero/");
            Chosen = _heroStaticData.FirstOrDefault();
        }

        public HeroStaticData Chosen { get; set; }

        public HeroStaticData[] LoadAll() => _heroStaticData;
    }
}