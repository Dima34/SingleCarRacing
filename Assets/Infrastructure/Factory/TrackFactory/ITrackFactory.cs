using Cinemachine;
using Infrastructure.Logic.Car;
using StaticData;
using UnityEngine;

namespace Infrastructure.Factory.TrackFactory
{
    public interface ITrackFactory
    {
        GameObject CreateGround();
        CinemachineVirtualCamera CreateCamera();
        void CreateHUD();
        GameObject CreateFinish();
        CarMovement CreateCar();
    }
}