using System.Collections.Generic;
using System.Linq;
using Infrastructure.Constants;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<string, LevelStaticData> _levels;
        private CarStaticData _car;

        public StaticDataService()
        {
            LoadCar();
            LoadLevels();
        }
        
        private void LoadLevels() =>
            _levels = TryLoadAll<LevelStaticData>(StaticDataPath.STATICDATA_LEVELS_PATH)
                .ToDictionary(x => x.LevelKey);
        
        public void LoadCar() =>
            _car = TryLoad<CarStaticData>(StaticDataPath.STATICDATA_CAR_PATH);

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData staticData) ? staticData : null;
        
        public CarStaticData Car() =>
            _car;

        private static T[] TryLoadAll<T>(string path) where T : UnityEngine.Object
        {
            T[] loadedResources = Resources.LoadAll<T>(path);
            
            if (loadedResources.Length == 0)
                throw new BadPathException($"Can`t find resources in path \"{path}\"");

            return loadedResources;
        }
        
        private static T TryLoad<T>(string path) where T : UnityEngine.Object
        {
            T loadedResource = Resources.Load<T>(path);
            
            if (loadedResource == null)
                throw new BadPathException($"Can`t find resource in path \"{path}\"");

            return loadedResource;
        }
    }
}