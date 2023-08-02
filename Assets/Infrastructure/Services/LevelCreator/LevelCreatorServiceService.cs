using Infrastructure.Factory.TrackFactory;
using Infrastructure.Logic.Car;
using Zenject;

namespace Infrastructure.Services.LevelCreator
{
    public class LevelCreatorServiceService : ILevelCreatorService
    {
        private ITrackFactory _trackFactory;

        [Inject]
        public void Construct(ITrackFactory trackFactory) =>
            _trackFactory = trackFactory;

        public void Initialize()
        {
            CreateGround(_trackFactory);
            var car = CreateCar(_trackFactory);
            CreateAndInitializeCamera(_trackFactory, car);
            CreateFinish(_trackFactory);
            CreateHUD(_trackFactory);
        }

        private void CreateFinish(ITrackFactory trackFactory) =>
            trackFactory.CreateFinish();

        private void CreateHUD(ITrackFactory trackFactroy) =>
            trackFactroy.CreateHUD();

        private static void CreateGround(ITrackFactory trackFactory) =>
            trackFactory.CreateGround();

        private static CarMovement CreateCar(ITrackFactory trackFactory) =>
            trackFactory.CreateCar();

        private static void CreateAndInitializeCamera(ITrackFactory trackFactory, CarMovement car) =>
            trackFactory.CreateAndInitializeCamera(car.transform);
    }
}