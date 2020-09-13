using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();

        if (player)
        {
            OnPlayerEnter(player);
        }
    }

    protected abstract void OnPlayerEnter(Player player);
}