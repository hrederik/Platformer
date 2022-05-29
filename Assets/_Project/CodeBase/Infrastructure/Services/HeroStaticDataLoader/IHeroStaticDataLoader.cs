using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services
{
    public interface IHeroStaticDataLoader
    {
        public HeroStaticData Chosen { get; set; }
        
        HeroStaticData[] LoadAll();
    }
}