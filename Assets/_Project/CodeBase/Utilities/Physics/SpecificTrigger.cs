using UnityEngine;
using UnityEngine.Events;

namespace Utilities.Physic
{
    public abstract class SpecificTrigger<T> : MonoBehaviour
    {
        public event UnityAction<T> Entered;
        public event UnityAction<T> Exited;
        

        private void OnTriggerEnter(Collider other)
        {
            InvokeIfTarget(other, Entered);
        }

        private void OnTriggerExit(Collider other)
        {
            InvokeIfTarget(other, Exited);
        }

        private void InvokeIfTarget(Collider other, UnityAction<T> callback)
        {
            var target = other.GetComponent<T>();

            if (target != null) 
                callback?.Invoke(target);
        }
    }
}