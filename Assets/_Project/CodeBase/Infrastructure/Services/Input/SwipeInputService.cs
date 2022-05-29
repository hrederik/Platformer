using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Infrastructure.Services.Input
{
    public class SwipeInputService : MonoBehaviour, IInputService
    {
        [SerializeField] private SwipeTracker _swipeTracker;

        public event UnityAction MovedForward
        {
            add => _swipeTracker.SwipedUp += value;
            remove => _swipeTracker.SwipedUp -= value;
        }
        
        public event UnityAction MovedBack
        {
            add => _swipeTracker.SwipedDown += value;
            remove => _swipeTracker.SwipedDown -= value;
        }
    }
}