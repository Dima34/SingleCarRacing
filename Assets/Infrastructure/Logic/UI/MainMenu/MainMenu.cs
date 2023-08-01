using Infrastructure.Constants;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Logic.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        private ILoadSceneService _loadSceneService;

        [Inject]
        public void Construct(ILoadSceneService loadSceneService) =>
            _loadSceneService = loadSceneService;

        private void Awake() =>
            _startButton.onClick.AddListener(LoadTrackLevel);

        private void LoadTrackLevel() =>
            _loadSceneService.LoadLevel(Scenes.TRACK_LEVEL);
    }
}