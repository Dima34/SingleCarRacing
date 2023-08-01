using Infrastructure.Constants;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
    private ILoadSceneService _loadSceneService;

    [Inject]
    public void Construct(ILoadSceneService loadSceneService) =>
        _loadSceneService = loadSceneService;

    private void Awake()
    {
        LoadMainMenu();
        DontDestroyOnLoad(this);
    }

    private void LoadMainMenu() =>
        _loadSceneService.LoadLevel(Scenes.MAINMENU_LEVEL);
}