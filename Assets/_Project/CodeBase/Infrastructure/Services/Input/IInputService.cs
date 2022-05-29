using UnityEngine.Events;

namespace CodeBase.Infrastructure.Services.Input
{
    public interface IInputService
    {
        event UnityAction MovedForward;
        event UnityAction MovedBack;
    }
}