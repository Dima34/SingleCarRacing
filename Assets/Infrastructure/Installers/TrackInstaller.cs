using Infrastructure.Factory.TrackFactory;
using Infrastructure.Services.LevelCreator;
using Zenject;

namespace Infrastructure.Installers
{
    public class TrackInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallTrackFactory();
            InstallLevelCreator();
        }

        private void InstallTrackFactory()
        {
            Container
                .BindInterfacesAndSelfTo<TrackFactory>()
                .AsSingle()
                .NonLazy();
        }

        private void InstallLevelCreator()
        {
            Container
                .BindInterfacesAndSelfTo<LevelCreatorServiceService>()
                .AsSingle();
        }
    }
}