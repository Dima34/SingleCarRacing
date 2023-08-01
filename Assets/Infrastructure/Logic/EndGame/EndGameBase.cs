using Infrastructure.Constants;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Infrastructure.Logic.EndGame
{
    public class EndGameBase : MonoBehaviour
    {
        internal bool _usedBefore;
        private ILoadSceneService _loadSceneService;

        [Inject]
        public void Construct(ILoadSceneService loadSceneService) =>
            _loadSceneService = loadSceneService;

        protected void EndGame() =>
            _loadSceneService.LoadLevel(Scenes.MAINMENU_LEVEL);
    }
}