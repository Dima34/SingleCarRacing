using Infrastructure.Logic.Car;
using UnityEngine;

namespace Infrastructure.Factory.TrackFactory
{
    public interface ITrackFactory
    {
        CarMovement CreateCar();
        void CreateGround();
        void CreateAndInitializeCamera(Transform transformToFollow);
        void CreateHUD();
        void CreateFinish();
    }
}