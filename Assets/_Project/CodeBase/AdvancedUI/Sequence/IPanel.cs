using UnityEngine.Events;

namespace AdvancedUI.Sequence
{
    public interface IPanel
    {
        event UnityAction<IPanel> Ready;
        event UnityAction Closed;

        void Spawn();
        void Hide();
    }
}