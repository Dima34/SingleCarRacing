using StaticData;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        LevelStaticData ForLevel(string sceneKey);
        CarStaticData Car();
    }
}