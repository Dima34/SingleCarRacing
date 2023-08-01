using UnityEngine.EventSystems;

namespace Infrastructure.Logic.UI.HeldDown
{
    public class HeldDownButton : EventTrigger
    {
        private bool _isHeldDown;

        public bool IsHeldDown => _isHeldDown;

        public override void OnPointerDown(PointerEventData eventData) =>
            _isHeldDown = true;

        public override void OnPointerUp(PointerEventData eventData) =>
            _isHeldDown = false;
    }
}