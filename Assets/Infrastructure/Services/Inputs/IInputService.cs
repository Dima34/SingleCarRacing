using UnityEngine;

namespace Services.Inputs
{
    public interface IInputService
    {
        void SetTouchAxis(Vector2 axis);
        Vector2 GetAxis();
    }
}