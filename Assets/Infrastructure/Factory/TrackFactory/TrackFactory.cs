using Cinemachine;
using Infrastructure.Constants;
using Infrastructure.Logic.Car;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.Factory.TrackFactory
{
    public class TrackFactory : ITrackFactory
    {
        private readonly DiContainer _diContainer;
        private LevelStaticData _levelStaticData;

        public TrackFactory(DiContainer diContainer,IStaticDataService staticDataService)
        {
            _levelStaticData = staticDataService.ForLevel(SceneManager.GetActiveScene().name);
            _diContainer = diContainer;
        }

        public CarMovement CreateCar() =>
            _diContainer
                .InstantiatePrefabResource(ResourceAddresses.CAR)
                .GetComponent<CarMovement>();

        public CinemachineVirtualCamera CreateCamera() =>
            _diContainer
                .InstantiatePrefabResource(ResourceAddresses.CAMERA)
                .GetComponentInChildren<CinemachineVirtualCamera>();

        public GameObject CreateGround() =>
            _diContainer
                .InstantiatePrefab(_levelStaticData.GroundPrefab);
        
        public void CreateHUD()
        {
            _diContainer
                .InstantiatePrefabResource(ResourceAddresses.HUD);
        }

        public GameObject CreateFinish() =>
            _diContainer
                .InstantiatePrefabResource(ResourceAddresses.FINISH);
    }
}