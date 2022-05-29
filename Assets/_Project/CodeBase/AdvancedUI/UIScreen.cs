using System.Collections;
using UnityEngine;

namespace AdvancedUI
{
    public abstract class UIScreen : MonoBehaviour
    {
        public abstract void Show();
        public abstract Coroutine Hide();

        protected Coroutine StartEmptyCoroutine()
        {
            var coroutine = StartCoroutine(EmptyCoroutine());
            return coroutine;
        }
        
        private IEnumerator EmptyCoroutine()
        {
            yield break;
        }
    }
}