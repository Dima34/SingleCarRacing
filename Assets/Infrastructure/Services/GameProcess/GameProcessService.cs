using UnityEngine;

namespace Infrastructure.Services.GameProcess
{
    public class GameProcessService : IGameProcessService
    {
        public void PauseGame() =>
            Time.timeScale = 0;

        public void ResumeGame() =>
            Time.timeScale = 1;
    }
}