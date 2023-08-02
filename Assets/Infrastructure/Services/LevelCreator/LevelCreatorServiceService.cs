using Cinemachine;
using Infrastructure.Factory.TrackFactory;
using Infrastructure.Logic.Car;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.Services.LevelCreator
{
    public class LevelCreatorServiceService : ILevelCreatorService
    {
        private ITrackFactory _trackFactory;
        private IStaticDataService _staticDataService;
        private LevelStaticData _levelStaticData;

        [Inject]
        public void Construct(ITrackFactory trackFactory, IStaticDataService staticDataService)
        {
            _trackFactory = trackFactory;
            _staticDataService = staticDataService;
            _levelStaticData = _staticDataService.ForLevel(SceneManager.GetActiveScene().name);
        }

        public void Initialize()
        {
            CreateGround(_trackFactory);
            var car = CreateCar(_trackFactory);
            CreateAndInitializeCamera(_trackFactory, car.transform);
            CreateFinish(_trackFactory);
            CreateHUD(_trackFactory);
        }

        private void CreateGround(ITrackFactory trackFactory)
        {
            GameObject ground = trackFactory.CreateGround();
            SetGroundPosition(ground);
        }
        
        private void SetGroundPosition(GameObject ground)
        {
            ground.transform.position = _levelStaticData.GroundPosition;
            ground.transform.rotation = _levelStaticData.GroundRotation;
            ground.transform.localScale = _levelStaticData.GroundScale;
        }

        private void CreateFinish(ITrackFactory trackFactory)
        {
            GameObject finish = trackFactory.CreateFinish();
            finish.transform.position = _levelStaticData.FinishPosition;
        }

        private void CreateHUD(ITrackFactory trackFactroy) =>
            trackFactroy.CreateHUD();

        private CarMovement CreateCar(ITrackFactory trackFactory)
        {
            CarMovement car = trackFactory.CreateCar();
            car.transform.position = _levelStaticData.StartPosition;
            
            var carData = _staticDataService.Car();
            car.Initialize(carData.Speed, carData.RotationSpeed, carData.SuspensionDamping,carData.CarMass);
            
            return car;
        }

        private static void CreateAndInitializeCamera(ITrackFactory trackFactory, Transform transformToFollow)
        {
            CinemachineVirtualCamera camera = trackFactory.CreateCamera();
            camera.Follow = transformToFollow;
        }
    }
}