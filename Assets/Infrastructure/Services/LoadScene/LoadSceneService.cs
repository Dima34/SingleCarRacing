using System;
using System.Collections;
using Logic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.States
{
    public class LoadSceneService : ILoadSceneService
    {
        private LoadingCurtain _loadingCurtain;
        private ICoroutineRunner _coroutineRunner;

        [Inject]
        public void Construct(LoadingCurtain loadingCurtain, ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _loadingCurtain = loadingCurtain;
        }

        public void LoadLevel(string levelName)
        {
            _loadingCurtain.Show();
            Load(levelName, OnLevelLoaded);
        }

        private void OnLevelLoaded() =>
            _loadingCurtain.Hide();
        
        public void Load(string name, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));

        public IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                yield break;
            }
        
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (!waitNextScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}