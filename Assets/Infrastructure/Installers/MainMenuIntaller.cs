using Infrastructure.Constants;
using Logic.MainMenu;
using Zenject;

namespace Infrastructure.Installers
{
    public class MainMenuIntaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMainMenu();
        }

        private void BindMainMenu()
        {
            Container
                .Bind<MainMenu>()
                .FromComponentInNewPrefabResource(ResourceAddresses.MAINMENU)
                .AsSingle()
                .NonLazy();
        }
    }
}