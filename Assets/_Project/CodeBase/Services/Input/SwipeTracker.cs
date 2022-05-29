using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace CodeBase.Services.Input
{
    public class SwipeTracker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private const float MinDelta = 300; 
        
        private Vector2 _startPoint;

        public event UnityAction SwipedUp;
        public event UnityAction SwipedDown;

        public void OnPointerDown(PointerEventData eventData)
        {
            _startPoint = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            var delta = eventData.position.y - _startPoint.y;
            if (Mathf.Abs(delta) < MinDelta) return;

            if (delta > 0)
                SwipedUp?.Invoke();
            else
                SwipedDown?.Invoke();
        }
    }
}