using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services.HeroStaticDataLoader
{
    public interface IHeroStaticDataLoader
    {
        public HeroStaticData Chosen { get; set; }
        
        HeroStaticData[] LoadAll();
    }
}