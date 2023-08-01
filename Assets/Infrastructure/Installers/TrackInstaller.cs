using Infrastructure.Factory.TrackFactory;
using Infrastructure.Logic.Car;
using Zenject;

namespace Infrastructure.Installers
{
    public class TrackInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            RegisterInializerAsInitializable();
            BindTrackFactory();
        }

        private void RegisterInializerAsInitializable()
        {
            Container
                .BindInterfacesTo<TrackInstaller>()
                .FromInstance(this)
                .AsSingle();
        }

        private void BindTrackFactory()
        {
            Container
                .BindInterfacesAndSelfTo<TrackFactory>()
                .AsSingle()
                .NonLazy();
        }

        public void Initialize()
        {
            ITrackFactory trackFactory = Container.Resolve<TrackFactory>();

            CreateGround(trackFactory);
            var car = CreateCar(trackFactory);
            CreateAndInitializeCamera(trackFactory, car);
            CreateFinish(trackFactory);
            CreateHUD(trackFactory);
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