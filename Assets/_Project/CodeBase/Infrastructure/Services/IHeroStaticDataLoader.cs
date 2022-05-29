using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services
{
    public interface IHeroStaticDataLoader
    {
        HeroStaticData[] LoadAll();
    }
}