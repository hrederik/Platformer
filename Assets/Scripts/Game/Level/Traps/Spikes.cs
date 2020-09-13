using System.Collections;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _showSpikesDelay;
    [SerializeField] private float _hideSpikesDelay;

    private void Start()
    {
        StartCoroutine(ActivateTrap());
    }

    private IEnumerator ActivateTrap()
    {
        while (true)
        {
            yield return new WaitForSeconds(_showSpikesDelay);
            _animator.SetTrigger("ShowSpikes");

            yield return new WaitForSeconds(_hideSpikesDelay);
            _animator.SetTrigger("HideSpikes");
        }
    }
}