namespace Infrastructure.Services.GameProcess
{
    public interface IGameProcessService
    {
        void PauseGame();
        void ResumeGame();
    }
}