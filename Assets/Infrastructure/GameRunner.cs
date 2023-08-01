using System;
using Infrastructure.Constants;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        private ILoadSceneService _loadSceneService;
        private static string INITIAL_SCENE_NAME = Scenes.INITIAL_SCENE;

        [Inject]
        public void Construct(ILoadSceneService loadSceneService) =>
            _loadSceneService = loadSceneService;

        private void Awake()
        {
            if (NotInitialScene() && !SceneContainsBootstrapper()) 
                LoadInitialScene();
        }

        private static bool NotInitialScene() =>
            SceneManager.GetActiveScene().name != INITIAL_SCENE_NAME;

        private bool SceneContainsBootstrapper() =>
            FindObjectOfType<GameBootstrapper>() != null;

        private void LoadInitialScene() =>
            _loadSceneService.LoadLevel(INITIAL_SCENE_NAME);
    }
}

