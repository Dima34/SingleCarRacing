using System;
using Infrastructure.Constants;
using Infrastructure.Services.GameProcess;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Infrastructure.Logic.UI.PauseMenu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private Button _openPauseButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _exitButton;
        private IGameProcessService _gameProcessService;
        private ILoadSceneService _loadSceneService;

        [Inject]
        public void Construct(IGameProcessService gameProcessService, ILoadSceneService loadSceneService)
        {
            _loadSceneService = loadSceneService;
            _gameProcessService = gameProcessService;
        }

        private void Start()
        {
            _openPauseButton.onClick.AddListener(OpenPauseMenu);
            _resumeButton.onClick.AddListener(ClosePauseMenu);
            _exitButton.onClick.AddListener(LoadMainMenu);
        }

        private void OpenPauseMenu()
        {
            PauseGame();
            _pauseMenu.SetActive(true);
        }

        private void PauseGame() =>
            _gameProcessService.PauseGame();

        private void ClosePauseMenu()
        {
            ResumeGame();
            _pauseMenu.SetActive(false);
        }

        private void LoadMainMenu()
        {
            ResumeGame();
            _loadSceneService.LoadLevel(Scenes.MAINMENU_LEVEL);
        }

        private void ResumeGame() =>
            _gameProcessService.ResumeGame();
    }
}