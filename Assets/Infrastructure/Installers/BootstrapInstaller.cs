using Infrastructure.Constants;
using Infrastructure.Services.GameProcess;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using Logic;
using Services.Inputs;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindCoroutineRunner();
            BindLoadSceneService();
            BindLoadingCurtain();
            BindStaticDataService();
            BindInputService();
            BindGameProcessService();
            
            BindGameBootstrapper();
        }

        private void BindStaticDataService()
        {
            Container
                .Bind<IStaticDataService>()
                .To<StaticDataService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<BootstrapInstaller>()
                .FromInstance(this)
                .AsSingle();
        }

        private void BindGameBootstrapper()
        {
            Container
                .Bind<GameBootstrapper>()
                .AsSingle();
        }

        private void BindLoadSceneService()
        {
            Container
                .Bind<ILoadSceneService>()
                .To<LoadSceneService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindLoadingCurtain()
        {
            Container
                .Bind<LoadingCurtain>()
                .FromComponentInNewPrefabResource(ResourceAddresses.LOADING_CURTAIN)
                .AsSingle();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .To<InputService>()
                .AsSingle();
        }

        private void BindGameProcessService()
        {
            Container
                .Bind<IGameProcessService>()
                .To<GameProcessService>()
                .AsSingle();
        }
    }
}