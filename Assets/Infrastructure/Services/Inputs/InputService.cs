using UnityEngine;

namespace Services.Inputs
{
    public class InputService : IInputService
    {
        private Vector2 _touchAxis;
        private Vector2 GetTouchAxis() => _touchAxis;
        private static Vector2 GetUnityAxis() => new Vector2(Input.GetAxis(HORIZONTAL_AXIS), 0);
        
        private const string HORIZONTAL_AXIS = "Horizontal";
        
        public void SetTouchAxis(Vector2 axis) =>
            _touchAxis = axis;

        public Vector2 GetAxis()
        {
            Vector2 axis = GetTouchAxis();

            if (axis == Vector2.zero)
                axis = GetUnityAxis();

            return axis;
        }
    }
}