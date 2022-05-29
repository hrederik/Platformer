using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services.HeroDataProvider
{
    public interface IStaticDataService
    {
        HeroStaticData HeroData { get; set; }
    }
}