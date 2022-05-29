using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services.HeroDataProvider
{
    public class DefaultStaticDataService : IStaticDataService
    {
        public HeroStaticData HeroData { get; set; }
    }
}