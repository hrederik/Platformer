using UnityEngine.Events;

namespace CodeBase.Services.Input
{
    public interface IInputService
    {
        event UnityAction MovedForward;
        event UnityAction MovedBack;
    }
}