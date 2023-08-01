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
        private readonly IStaticDataService _staticDataService;
        private LevelStaticData _levelStaticData;

        public TrackFactory(DiContainer diContainer, IStaticDataService staticDataService)
        {
            _diContainer = diContainer;
            _staticDataService = staticDataService;
            _levelStaticData = _staticDataService.ForLevel(SceneManager.GetActiveScene().name);
        }

        public CarMovement CreateCar()
        {
            CarMovement car = _diContainer
                .InstantiatePrefabResource(ResourceAddresses.CAR)
                .GetComponent<CarMovement>();
            
            CarStaticData staticData = _staticDataService.Car();
            car.transform.position = _levelStaticData.StartPosition;
            car.Initialize(staticData.Speed, staticData.RotationSpeed, staticData.SuspensionDamping,staticData.CarMass);

            return car;
        }

        public void CreateAndInitializeCamera(Transform transformToFollow)
        {
            CinemachineVirtualCamera virtualCamera = _diContainer
                .InstantiatePrefabResource(ResourceAddresses.CAMERA)
                .GetComponentInChildren<CinemachineVirtualCamera>();

            virtualCamera.Follow = transformToFollow;
        }

        public void CreateGround()
        {
            GameObject ground = _diContainer
                .InstantiatePrefab(_levelStaticData.GroundPrefab);

            FillGroundTransform(ground);
        }

        private void FillGroundTransform(GameObject ground)
        {
            ground.transform.position = _levelStaticData.GroundPosition;
            ground.transform.rotation = _levelStaticData.GroundRotation;
            ground.transform.localScale = _levelStaticData.GroundScale;
        }

        public void CreateHUD()
        {
            _diContainer
                .InstantiatePrefabResource(ResourceAddresses.HUD);
        }

        public void CreateFinish()
        {
            GameObject finish = _diContainer
                .InstantiatePrefabResource(ResourceAddresses.FINISH);
            
            finish.transform.position = _levelStaticData.FinishPosition;
        }
    }
}