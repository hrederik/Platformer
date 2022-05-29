using System.Collections;
using UnityEngine;

namespace CodeBase.Game.Level.Traps
{
    public class Rockfall : MonoBehaviour
    {
        [SerializeField] private float _fallDelay;
        [SerializeField] private Animator _animator;

        private void Start()
        {
            StartCoroutine(ActivateTrap());
        }

        private IEnumerator ActivateTrap()
        {
            while (true)
            {
                yield return new WaitForSeconds(_fallDelay);
                _animator.SetTrigger("Fall");
            }
        }
    }
}
