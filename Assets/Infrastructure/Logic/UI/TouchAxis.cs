using Infrastructure.Logic.UI.HeldDown;
using Services.Inputs;
using UnityEngine;
using Zenject;

namespace Infrastructure.Logic.UI
{
    public class TouchAxis : MonoBehaviour
    {
        [SerializeField] private HeldDownButton _buttonLeft;
        [SerializeField] private HeldDownButton _buttonRight;
        
        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void Update()
        {
            Vector2 currentAxis = GetAxis();
            _inputService.SetTouchAxis(currentAxis);
        }

        private Vector2 GetAxis()
        {
            if (_buttonLeft.IsHeldDown)
                return new Vector2(-1, 0);
            else if (_buttonRight.IsHeldDown)
                return new Vector2(1, 0);
            else
                return new Vector2(0, 0);
        }
    }
}