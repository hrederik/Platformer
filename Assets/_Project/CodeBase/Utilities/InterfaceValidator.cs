using UnityEngine;

namespace Utilities
{
    public class InterfaceValidator : MonoBehaviour
    {
        public static void TryToValidate<T>(MonoBehaviour checkable)
        {
            if (checkable == null) return;
            if (checkable is T == false) 
                Debug.LogError($"{checkable.name} needs to implement {typeof(T).Name}");
        }
    }
}